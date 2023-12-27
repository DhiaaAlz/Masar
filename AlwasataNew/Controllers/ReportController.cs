using AlwasataNew.Data;
using AlwasataNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace AlwasataNew.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CustomerReports()
        {
            using var dbContext = new ApplicationDbContext();
            var customers = dbContext.Customers.ToList();
            return View(customers);
        }

        public IActionResult EmployeeReports()
        {
            using var dbContext = new ApplicationDbContext();
            var employee = dbContext.Users.ToList();
            return View(employee);
        }

        public IActionResult SalesReports()
        {
            return View();
        }


        public List<Customer> GetAllCustomer()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (User.IsInRole("Admin"))
                {
                    var allCustomer = dbContext.Customers.OrderBy(x => x.CreatedAt).AsNoTracking().ToList();
                    return allCustomer;
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var resultt = dbContext.Users.Where(x => x.Id == userId).Select(x => new { FName = x.FirstName, LName = x.LastName }).FirstOrDefault();

                    string EmployeeName = resultt.FName + " " + resultt.LName;


                    var allCustomer = dbContext.Customers.Where(x => x.FollowBy == EmployeeName).OrderBy(x => x.CreatedAt).AsNoTracking().ToList();
                    return allCustomer;
                }

            }
        }

        public JsonResult GetAllCustomerWithKeyWord(string text)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string constr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(constr);
            if (User.IsInRole("Admin"))
            {
                string s1 = $"select * from Customers where CustomerName like '%{text}%' or Phone like '%{text}%' or CompanyName like '%{text}%' or Email like '%{text}%'";
                SqlCommand cmd = new SqlCommand(s1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                da.Fill(ds);

                List<Customer> ListCustomer = new List<Customer>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ListCustomer.Add(new Customer
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CustomerName = dr["CustomerName"].ToString(),
                        CompanyName = dr["CompanyName"].ToString(),
                        CompanySite = dr["CompanySite"].ToString(),
                        CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                        CustomerState = dr["CustomerState"].ToString(),
                        Address = dr["Address"].ToString(),
                        Email = dr["Email"].ToString(),
                        FollowBy = dr["FollowBy"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = Convert.ToString(dr["Phone"]),
                        Type = dr["Type"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString()
                    });
                }

                return Json(ListCustomer);
            }
            else
            {
                using var dbContext = new ApplicationDbContext();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var result = dbContext.Users.Where(x => x.Id == userId).Select(x => new { FName = x.FirstName, LName = x.LastName }).FirstOrDefault();

                string EmployeeName = result.FName + " " + result.LName;


                string s1 = $"select * from Customers where (CustomerName like '%{text}%' or Phone like '%{text}%' or CompanyName like '%{text}%' or Email like '%{text}%') and FollowBy ='{EmployeeName}'";
                SqlCommand cmd = new SqlCommand(s1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                da.Fill(ds);

                List<Customer> ListCustomer = new List<Customer>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ListCustomer.Add(new Customer
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CustomerName = dr["CustomerName"].ToString(),
                        CompanyName = dr["CompanyName"].ToString(),
                        CompanySite = dr["CompanySite"].ToString(),
                        CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                        CustomerState = dr["CustomerState"].ToString(),
                        Address = dr["Address"].ToString(),
                        Email = dr["Email"].ToString(),
                        FollowBy = dr["FollowBy"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = Convert.ToString(dr["Phone"]),
                        Type = dr["Type"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString()
                    });
                }

                return Json(ListCustomer);

            }
        }

        public JsonResult GetAllCustomersLastMonth()
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string constr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(constr);
            int month = DateTime.Now.Month;
            string s1 = $"select * from Customers where MONTH(CreatedAt) = ${month}";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Customer> ListCustomer = new List<Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListCustomer.Add(new Customer
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    CustomerName = dr["CustomerName"].ToString(),
                    CompanyName = dr["CompanyName"].ToString(),
                    CompanySite = dr["CompanySite"].ToString(),
                    CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                    CustomerState = dr["CustomerState"].ToString(),
                    Address = dr["Address"].ToString(),
                    Email = dr["Email"].ToString(),
                    FollowBy = dr["FollowBy"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    JobTitle = dr["JobTitle"].ToString(),
                    Phone = Convert.ToString(dr["Phone"]),
                    Type = dr["Type"].ToString(),
                    CreatedBy = dr["CreatedBy"].ToString()
                });
            }

            return Json(ListCustomer);
        }

        public JsonResult GetAllCustomersLastYear()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string constr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(constr);
            int year = DateTime.Now.Year;
            string s1 = $"select * from Customers where YEAR(CreatedAt) = ${year}";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Customer> ListCustomer = new List<Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListCustomer.Add(new Customer
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    CustomerName = dr["CustomerName"].ToString(),
                    CompanyName = dr["CompanyName"].ToString(),
                    CompanySite = dr["CompanySite"].ToString(),
                    CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                    CustomerState = dr["CustomerState"].ToString(),
                    Address = dr["Address"].ToString(),
                    Email = dr["Email"].ToString(),
                    FollowBy = dr["FollowBy"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    JobTitle = dr["JobTitle"].ToString(),
                    Phone = Convert.ToString(dr["Phone"]),
                    Type = dr["Type"].ToString(),
                    CreatedBy = dr["CreatedBy"].ToString()
                });
            }

            return Json(ListCustomer);
        }

        public JsonResult GetAllCustomersBetweenDate(string sDate,string eDate)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string constr = configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(constr);

            string s1 = $"select * from Customers where CreatedAt >= CAST('{sDate}' as date) and CreatedAt <= CAST('{eDate}' as date)";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Customer> ListCustomer = new List<Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListCustomer.Add(new Customer
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    CustomerName = dr["CustomerName"].ToString(),
                    CompanyName = dr["CompanyName"].ToString(),
                    CompanySite = dr["CompanySite"].ToString(),
                    CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                    CustomerState = dr["CustomerState"].ToString(),
                    Address = dr["Address"].ToString(),
                    Email = dr["Email"].ToString(),
                    FollowBy = dr["FollowBy"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    JobTitle = dr["JobTitle"].ToString(),
                    Phone = Convert.ToString(dr["Phone"]),
                    Type = dr["Type"].ToString(),
                    CreatedBy = dr["CreatedBy"].ToString()
                });
            }

            return Json(ListCustomer);
        }
    }
}
