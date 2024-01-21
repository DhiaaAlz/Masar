using AlwasataNew.Data;
using AlwasataNew.Models;
using AlwasataNew.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace AlwasataNew.Controllers
{
    public class CustomerController : Controller
    {

        ApplicationDbContext dbContext = new ApplicationDbContext();

        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNew(string? viewbag)
        {
            if(viewbag != null)
            {
                ViewBag.done = "تم اضافة عميل جديد";
            }
            else
            {
                ViewBag.done = null;
            }
            return View();
        }

       


        [HttpPost]
        public IActionResult AddNew(AddCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            using (var DbContext = new ApplicationDbContext())
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var resultt = dbContext.Users.Where(x => x.Id == userId).Select(x => new { FName = x.FirstName, LName = x.LastName }).FirstOrDefault();

                string EmployeeName = resultt.FName + " " + resultt.LName;

                var CustomerResult = DbContext.Customers.Where(x => x.Phone == model.Phone).FirstOrDefault();

                if (CustomerResult != null)
                {
                    var maxProjectId = 0;
                    var result = DbContext.Projects.Count();

                    if (result != 0)
                    {
                        maxProjectId = DbContext.Projects.Max(x => x.Id) + 1;
                    }
                    else
                    {
                        maxProjectId++;
                    }

                    if (model.ProjectType != "مباني سكنية")
                    {
                        model.DescriptionType = "";
                    }
                    if (model.ProjectModel == "اخرى")
                    {
                        model.ProjectModel = model.OtherProjectModel;
                    }
                    var project = new Project
                    {
                        Id = maxProjectId,
                        Description = model.Description,
                        Type = model.ProjectType,
                        DescriptionType = model.DescriptionType,
                        LandAreaByM = model.LandAreaByM,
                        Model = model.ProjectModel,
                        CustomerId = CustomerResult.Id,
                        IsDone = false,

                    };
                    DbContext.Projects.Add(project);
                    DbContext.SaveChanges();
                }

                else
                {
                    
                    var maxCustomerId = 0;
                    var result = DbContext.Customers.Count();

                    if (result != 0)
                    {
                        maxCustomerId = DbContext.Customers.Max(x => x.Id) + 1;
                    }
                    else
                    {
                        maxCustomerId++;
                    }

                    var clientSource = "";

                    if(model.CustomerComeFrom=="داتا" || model.CustomerComeFrom=="اخر")
                    {
                        clientSource = model.ClientSourceDataAndOther;
                    }
                    else if (model.CustomerComeFrom == "مسوقين")
                    {
                        clientSource = model.ClientSourceMarkter;
                    }
                    else if(model.CustomerComeFrom=="موظفين")
                    {
                        clientSource = model.ClientSourceEmployee;
                    }
                    else if (model.CustomerComeFrom == "حملات التسويق")
                    {
                        clientSource = model.MarktingCampaigns;
                    }
                    else
                    {
                        clientSource = "لايوجد";
                    }
                    if(model.FollowByEmployee == "اختر")
                    {
                        model.FollowByEmployee = null;
                    }
                    var customer = new Customer
                    {
                        Id = maxCustomerId,
                        CustomerName = model.CustomerName,
                        Email = model.Email,
                        Phone = model.Phone,
                        CustomerDescription = model.CustomerDescription,
                        Type = model.Type,
                        CreatedBy = EmployeeName,
                        CreatedAt = DateTime.Now.ToString(),
                        CompanyName = model.CompnayName,
                        EmployeeName = model.EmployeeName,
                        FollowBy=model.FollowByEmployee,
                        CustomerComeFrom=model.CustomerComeFrom,
                        ClientSource=clientSource,
                        JobTitle = model.JobTitle,
                        CustomerState = "جديد",
                        CompanySite = model.CompanySite,
                        Address = model.Address,
                        CompanyId = model.ForCompany
                    };

                    DbContext.Customers.Add(customer);
                    DbContext.SaveChanges();

                    var maxProjectId = 0;

                    var resultProject = DbContext.Projects.Count();

                    if (resultProject != 0)
                    {
                        maxProjectId = DbContext.Projects.Max(x => x.Id) + 1;
                    }
                    else
                    {
                        maxProjectId++;
                    }
                    if (model.ProjectType != "مباني سكنية")
                    {
                        model.DescriptionType = "";
                    }
                    if (model.ProjectModel == "اخرى")
                    {
                        model.ProjectModel = model.OtherProjectModel;
                    }

                    var testModeel = model;
                    Project p1 = new Project();
                    p1.Id = maxProjectId;
                    p1.Description = model.Description;
                    p1.Type = model.ProjectType;
                    p1.DescriptionType = model.DescriptionType;
                    p1.LandAreaByM = model.LandAreaByM;
                    p1.Model = model.ProjectModel;
                    p1.CustomerId = maxCustomerId;
                    p1.IsDone = false;

                    DbContext.Projects.Add(p1);
                    DbContext.SaveChanges();
                }

            }

            ViewBag.done = "تم اضافة عميل جديد";
            return RedirectToAction("AddNew","Customer",new{ viewbag="تم اضافة عميل جديد"});
        }



        [HttpGet]
        public IActionResult ShowListOfCustomerByState(string state, string empId)
        {
            var result = new List<Customer>();
            if (state == "جديد")
            {
                result = dbContext.Customers.Where(x => x.FollowBy == empId && (x.CustomerState == state || x.CustomerState == "رد" || x.CustomerState == "لم يرد" || x.CustomerState == "متفاعل" || x.CustomerState == "غير متفاعل")).ToList();
            }
            else
            {
                result = dbContext.Customers.Where(x => x.FollowBy == empId && x.CustomerState == state).ToList();
            }
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> ManageCustomer()
        {
            using (var DbContext = new ApplicationDbContext())
            {

                if (User.IsInRole("Admin"))
                {

                    var Customer = await DbContext.Customers.Select(customer => new CustomerViewModel
                    {
                        Id = customer.Id,
                        Name = customer.CustomerName,
                        Phone = customer.Phone,
                        Type = customer.Type,
                        Email = customer.Email,
                        CompanyName = customer.CompanyName,
                        EmployeeName = customer.EmployeeName,
                        FollowBy = customer.FollowBy,
                        CustomerState = customer.CustomerState,
                        CustomerComeFrom=customer.CustomerComeFrom
                        ,ClientSource=customer.ClientSource,
                        ProjectsId = DbContext.Projects.Where(x => x.CustomerId == customer.Id).Select(x => x.Id).ToList(),
                    }).AsNoTracking().ToListAsync();


                    return View(Customer);
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    

                    


                    var Customer = await DbContext.Customers.Select(customer => new CustomerViewModel
                    {
                        Id = customer.Id,
                        Name = customer.CustomerName,
                        Phone = customer.Phone,
                        Type = customer.Type,
                        Email = customer.Email,
                        CompanyName = customer.CompanyName,
                        EmployeeName = customer.EmployeeName,
                        FollowBy = customer.FollowBy,
                        CustomerState = customer.CustomerState,
                        CustomerComeFrom = customer.CustomerComeFrom
                        ,
                        ClientSource = customer.ClientSource,
                        ProjectsId = DbContext.Projects.Where(x => x.CustomerId == customer.Id).Select(x => x.Id).ToList(),
                    }).Where(x => x.FollowBy == userId).ToListAsync();


                    return View(Customer);
                }

            }

        }


        [HttpGet]
        public IActionResult ShowProjects(int Id)
        {
            if (User.IsInRole("Admin"))
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var CustomerProjects = dbContext.Projects
                        .Select(project => new ShowProjectsViewModel
                        {
                            Id = project.Id,
                            Description = project.Description,
                            Type = project.Type,
                            DescriptionType = project.DescriptionType,
                            LandAreaByM = project.LandAreaByM,
                            Model = project.Model,
                            CustomerId = project.CustomerId
                        })
                        .Where(x => x.CustomerId == Id).AsNoTracking().ToList();
                    return View(CustomerProjects);
                }

            }
            else
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                

                using (var dbContext = new ApplicationDbContext())
                {
                    var custId = dbContext.Customers.Where(x => x.FollowBy == userId).Select(x => x.Id).ToList();
                    var CustomerProjects = dbContext.Projects
                        .Select(project => new ShowProjectsViewModel
                        {
                            Id = project.Id,
                            Description = project.Description,
                            Type = project.Type,
                            DescriptionType = project.DescriptionType,
                            LandAreaByM = project.LandAreaByM,
                            Model = project.Model,
                            CustomerId = project.CustomerId
                        })
                        .Where(x => x.CustomerId == Id).ToList();

                    int checkIfThisProjectForThisEmp = 0;

                    foreach (int item in custId)
                    {
                        var result = CustomerProjects.FirstOrDefault(x => x.CustomerId == item);
                        if (result != null)
                        {
                            checkIfThisProjectForThisEmp++;
                        }
                    }
                    if (checkIfThisProjectForThisEmp != 0)
                    {
                        return View(CustomerProjects);
                    }
                    else
                    {
                        return View(CustomerProjects = new List<ShowProjectsViewModel>());
                    }
                }
            }

        }





        [HttpGet]
        public IActionResult ShowProjectsDescription(int projId)
        {

            if (User.IsInRole("Admin"))
            {
                using (var dbContext = new ApplicationDbContext())
                {

                    var result = dbContext.Projects.Where(x => x.Id == projId).AsNoTracking().FirstOrDefault();
                    return View(result);
                }
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                using (var dbContext = new ApplicationDbContext())
                {
                    var custId = dbContext.Customers.Where(x => x.FollowBy == userId).Select(x => x.Id).ToList();

                    int IfThisProjToEmp = 0;
                    foreach (var item in custId)
                    {
                        if (item == dbContext.Projects.Where(x => x.Id == projId).Select(x => x.CustomerId).FirstOrDefault())
                        {
                            IfThisProjToEmp++;
                        }
                    }
                    if (IfThisProjToEmp > 0)
                    {
                        return View(dbContext.Projects.Where(x => x.Id == projId).FirstOrDefault());
                    }
                    else
                    {
                        return View();
                    }

                }
            }

        }

        [HttpGet]
        public IActionResult EditInformation(int Id)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var customer = dbContext.Customers.AsNoTracking().FirstOrDefault(x => x.Id == Id);
                var project = dbContext.Projects.AsNoTracking().FirstOrDefault(x => x.CustomerId == Id);
                if (customer == null || project == null)
                {
                    return View(new EditCustomerViewModel());
                }
                var CustomerInformation = new EditCustomerViewModel
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Type = customer.Type,
                    CreatedBy = customer.CreatedBy,
                    CompanyName = customer.CompanyName,
                    EmployeeName = customer.EmployeeName,
                    JobTitle = customer.JobTitle,
                    CustomerState = customer.CustomerState,
                    CompanySite = customer.CompanySite,
                    Address = customer.Address,
                    ProjectId = project.Id,
                    ProjectDescription = project.Description,
                    ProjectType = project.Type,
                    DescriptionProjectType = project.DescriptionType,
                    ProjectLandArea = project.LandAreaByM,
                    ProjectModel = project.Model,
                    FollowBy = customer.FollowBy,
                    ForCompany = customer.CompanyId,
                };

                return View(CustomerInformation);
            }

        }

        [HttpPost]
        public IActionResult EditInformation(EditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var dbContext = new ApplicationDbContext())
            {
                var customer = dbContext.Customers.Where(x => x.Id == model.Id).FirstOrDefault();
                var prjId = model.ProjectId;
                var project = dbContext.Projects.Where(x => x.Id == model.ProjectId).FirstOrDefault();
                if (customer == null || project == null)
                    NotFound();


                if (model.Email != null)
                {
                    var CustomerWithSameEmail = dbContext.Customers.FirstOrDefault(x => x.Email == model.Email);


                    if (CustomerWithSameEmail != null && CustomerWithSameEmail.Id != model.Id)
                    {
                        ModelState.AddModelError("Email", "هذا الايميل مستخدم من قبل عميل اخر !");
                        return View(model);
                    }
                }



                var CustomerWithSamePhone = dbContext.Customers.FirstOrDefault(x => x.Phone == model.Phone);

                if (CustomerWithSamePhone != null && CustomerWithSamePhone.Id != model.Id)
                {
                    ModelState.AddModelError("Phone", "هذا رقم الهاتف مستخدم من قبل عميل اخر!");
                    return View(model);
                }
                var clientSource = "";

                if (model.CustomerComeFrom == "داتا" || model.CustomerComeFrom == "اخر")
                {
                    clientSource = model.ClientSourceDataAndOther;
                }
                else if (model.CustomerComeFrom == "مسوقين")
                {
                    clientSource = model.ClientSourceMarkter;
                }
                else if (model.CustomerComeFrom == "موظفين")
                {
                    clientSource = model.ClientSourceEmployee;
                }
                else
                {
                    clientSource = "لايوجد";
                }

                customer.CustomerName = model.CustomerName;
                customer.Phone = model.Phone;
                customer.Email = model.Email;
                customer.Type = model.Type;
                customer.CompanyId = dbContext.Companies.Where(x => x.Id == model.ForCompany).Select(x => x.Id).FirstOrDefault();
                

                customer.CompanyName = model.CompanyName;
                customer.EmployeeName = model.EmployeeName;
                customer.JobTitle = model.JobTitle;
                customer.Address = model.Address;
                customer.CustomerState = model.CustomerState;
                customer.CompanyId = model.ForCompany;

                if(model.CustomerComeFrom != null)
                {
                    customer.CustomerComeFrom = model.CustomerComeFrom;
                    customer.ClientSource = clientSource;
                }

                //update project
                project.Description = model.ProjectDescription;
                project.DescriptionType = model.DescriptionProjectType;
                project.LandAreaByM = model.ProjectLandArea;
                project.Type = model.ProjectType;
                project.Model = model.ProjectModel;

                if (customer.CustomerState == "مكتمل")
                {
                    project.IsDone = true;
                }

                

                ViewBag.done = "تم التعديل بنجاح";

                if(customer.FollowBy != model.FollowBy && customer.FollowBy==null)
                {
                    if (model.FollowBy != null)
                    {
                        customer.FollowBy = model.FollowBy;
                    }
                    dbContext.Projects.Update(project);
                    dbContext.Customers.Update(customer);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "ManageProject");
                }
                else
                {
                    if (model.FollowBy != null)
                    {
                        customer.FollowBy = model.FollowBy;
                    }
                    dbContext.Projects.Update(project);
                    dbContext.Customers.Update(customer);
                    dbContext.SaveChanges();
                    return View(model);
                }
                
            }
        }

        [HttpGet]
        public IActionResult CustomerStateComment(int customerId)
        {
            using var dbContext = new ApplicationDbContext();
            var result = dbContext.Customers.Where(x => x.Id == customerId).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        public IActionResult CustomerStateComment(int customerId, string employeeId, string comment)
        {
            using (var dbcontext = new ApplicationDbContext())
            {
                if(comment=="done" || comment== "noAnswer")
                {
                    var customer = dbcontext.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                    if (comment == "done")
                        customer.CustomerState = "متفاعل";
                    else
                        customer.CustomerState = "لم يرد";
                    dbcontext.Customers.Update(customer);
                    dbcontext.SaveChanges();
                }
                else
                {
                    var currentDate = DateTime.Now;
                    var employeeID = dbcontext.Users.Where(x => x.Id == Convert.ToString(employeeId)).Select(x => x.Id).FirstOrDefault();
                    var maxId = 0;
                    var maxIdResult = dbcontext.CustomerStateDescriptions;
                    if (maxIdResult.Count() == 0)
                    {
                        maxId = 1;
                    }
                    else
                    {
                        maxId = (maxIdResult.Max(x => x.Id) + 1);
                    }



                    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    string constr = configuration.GetConnectionString("DefaultConnection");
                    SqlConnection con = new SqlConnection(constr);


                    string s1 = $"insert into CustomerStateDescriptions values(@maxId,@custId,@comment,@createAt,@empId)";
                    SqlCommand cmd = new SqlCommand(s1, con);

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@maxId";
                    param1.Value = maxId;
                    param1.SqlDbType = SqlDbType.Int;

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@custId";
                    param2.Value = Convert.ToInt32(customerId);
                    param2.SqlDbType = SqlDbType.Int;

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@comment";
                    param3.Value = comment;
                    param3.SqlDbType = SqlDbType.NVarChar;

                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@createAt";
                    param4.Value = currentDate;
                    param4.SqlDbType = SqlDbType.DateTime2;

                    SqlParameter param5 = new SqlParameter();
                    param5.ParameterName = "@empId";
                    param5.Value = Convert.ToString(employeeId);
                    param5.SqlDbType = SqlDbType.NVarChar;

                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);
                    cmd.Parameters.Add(param5);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    var result = dbcontext.CustomerStateDescriptions.Where(x => x.CustomerId == customerId && (x.CommentText == "تم التواصل عن طريق المكالمات" || x.CommentText == "تم التواصل عن طريق الايميل" || x.CommentText == "تم التواصل عن طريق الواتس اب")).ToList();
                    if (result.Count >= 3)
                    {
                        var customer = dbcontext.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                        if (customer != null)
                        {
                            if (customer.CustomerState == "جديد")
                            {
                                customer.CustomerState = "لم يرد";
                                dbcontext.SaveChanges();
                            }
                        }

                    }
                }
                
                return View(dbcontext.Customers.Where(x => x.Id == customerId).FirstOrDefault());
            }

        }

        public List<Project> GetAllProjects()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var allProjects = dbContext.Projects.OrderBy(x => x.Id).AsNoTracking().ToList();
                return allProjects;
            }
        }

        public List<CustomerStateDescription> GetAllCustomerStateDescription()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var allCustomerStateDescription = dbContext.CustomerStateDescriptions.OrderBy(x => x.Id).AsNoTracking().ToList();
                return allCustomerStateDescription;
            }
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

                  

                    var allCustomer = dbContext.Customers.Where(x => x.FollowBy == userId).OrderBy(x => x.CreatedAt).AsNoTracking().ToList();
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
                        CreatedAt = Convert.ToString(dr["CreatedAt"]),
                        CustomerState = dr["CustomerState"].ToString(),
                        Address = dr["Address"].ToString(),
                        Email = dr["Email"].ToString(),
                        FollowBy = dr["FollowBy"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        ClientSource = dr["ClientSource"].ToString(),
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
                        CreatedAt = Convert.ToString(dr["CreatedAt"]),
                        CustomerState = dr["CustomerState"].ToString(),
                        Address = dr["Address"].ToString(),
                        Email = dr["Email"].ToString(),
                        ClientSource = dr["ClientResource"].ToString(),
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
}
