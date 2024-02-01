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

        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNew(string? viewbag)
        {
            if (viewbag != null)
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




            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultt = _context.Users.Where(x => x.Id == userId).Select(x => new { FName = x.FirstName, LName = x.LastName }).FirstOrDefault();

            string EmployeeName = resultt.FName + " " + resultt.LName;

            var CustomerResult = _context.Customers.Where(x => x.Phone == model.Phone).FirstOrDefault();

            if (CustomerResult != null)
            {
                var maxProjectId = 0;
                var result = _context.Projects.Count();

                if (result != 0)
                {
                    maxProjectId = _context.Projects.Max(x => x.Id) + 1;
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
                _context.Projects.Add(project);
                _context.SaveChanges();
            }

            else
            {

                var maxCustomerId = 0;
                var result = _context.Customers.Count();

                if (result != 0)
                {
                    maxCustomerId = _context.Customers.Max(x => x.Id) + 1;
                }
                else
                {
                    maxCustomerId++;
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
                else if (model.CustomerComeFrom == "حملات التسويق")
                {
                    clientSource = model.MarktingCampaigns;
                }
                else
                {
                    clientSource = "لايوجد";
                }
                if (model.FollowByEmployee == "اختر")
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
                    FollowBy = model.FollowByEmployee,
                    CustomerComeFrom = model.CustomerComeFrom,
                    ClientSource = clientSource,
                    JobTitle = model.JobTitle,
                    CustomerState = "جديد",
                    CompanySite = model.CompanySite,
                    Address = model.Address,
                    CompanyId = model.ForCompany
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();

                var maxProjectId = 0;

                var resultProject = _context.Projects.Count();

                if (resultProject != 0)
                {
                    maxProjectId = _context.Projects.Max(x => x.Id) + 1;
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

                _context.Projects.Add(p1);
                _context.SaveChanges();


            }

            ViewBag.done = "تم اضافة عميل جديد";
            return RedirectToAction("AddNew", "Customer", new { viewbag = "تم اضافة عميل جديد" });
        }


        [HttpGet]
        public IActionResult ShowListOfCustomerByState(string state, string empId)
        {
            var result = new List<Customer>();
            if (state == "جديد")
            {
                result = _context.Customers.Where(x => x.FollowBy == empId && (x.CustomerState == state || x.CustomerState == "لم يرد" || x.CustomerState == "تم ارسال البيانات")).ToList();

            }
            else
            {
                result = _context.Customers.Where(x => x.FollowBy == empId && x.CustomerState == state).ToList();

            }


            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> ManageCustomer()
        {


            if (User.IsInRole("Admin"))
            {

                var Customer = await _context.Customers.Select(customer => new CustomerViewModel
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
                    ProjectsId = _context.Projects.Where(x => x.CustomerId == customer.Id).Select(x => x.Id).ToList(),
                }).AsNoTracking().ToListAsync();


                return View(Customer);
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);






                var Customer = await _context.Customers.Select(customer => new CustomerViewModel
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
                    ProjectsId = _context.Projects.Where(x => x.CustomerId == customer.Id).Select(x => x.Id).ToList(),
                }).Where(x => x.FollowBy == userId).ToListAsync();


                return View(Customer);
            }



        }


        [HttpGet]
        public IActionResult ShowProjects(int Id)
        {
            if (User.IsInRole("Admin"))
            {

                var CustomerProjects = _context.Projects
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
            else
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var custId = _context.Customers.Where(x => x.FollowBy == userId).Select(x => x.Id).ToList();
                var CustomerProjects = _context.Projects
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


        [HttpGet]
        public IActionResult ShowProjectsDescription(int projId)
        {

            if (User.IsInRole("Admin"))
            {


                var result = _context.Projects.Where(x => x.Id == projId).AsNoTracking().FirstOrDefault();
                return View(result);

            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



                var custId = _context.Customers.Where(x => x.FollowBy == userId).Select(x => x.Id).ToList();

                int IfThisProjToEmp = 0;
                foreach (var item in custId)
                {
                    if (item == _context.Projects.Where(x => x.Id == projId).Select(x => x.CustomerId).FirstOrDefault())
                    {
                        IfThisProjToEmp++;
                    }
                }
                if (IfThisProjToEmp > 0)
                {
                    return View(_context.Projects.Where(x => x.Id == projId).FirstOrDefault());
                }
                else
                {
                    return View();
                }


            }

        }

        [HttpGet]
        public IActionResult EditInformation(int Id)
        {

            var customer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            var project = _context.Projects.AsNoTracking().FirstOrDefault(x => x.CustomerId == Id);
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

        [HttpPost]
        public IActionResult EditInformation(EditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var customer = _context.Customers.Where(x => x.Id == model.Id).FirstOrDefault();
            var prjId = model.ProjectId;
            var project = _context.Projects.Where(x => x.Id == model.ProjectId).FirstOrDefault();

            if (customer == null || project == null)
                NotFound();


            if (model.Email != null)
            {
                var CustomerWithSameEmail = _context.Customers.FirstOrDefault(x => x.Email == model.Email);


                if (CustomerWithSameEmail != null && CustomerWithSameEmail.Id != model.Id)
                {
                    ModelState.AddModelError("Email", "هذا الايميل مستخدم من قبل عميل اخر !");
                    return View(model);
                }
            }



            var CustomerWithSamePhone = _context.Customers.FirstOrDefault(x => x.Phone == model.Phone);

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
            customer.CompanyId = _context.Companies.Where(x => x.Id == model.ForCompany).Select(x => x.Id).FirstOrDefault();


            customer.CompanyName = model.CompanyName;
            customer.EmployeeName = model.EmployeeName;
            customer.JobTitle = model.JobTitle;
            customer.Address = model.Address;
            customer.CustomerState = model.CustomerState;
            customer.CompanyId = model.ForCompany;

            if (model.CustomerComeFrom != null)
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

            if (customer.FollowBy != model.FollowBy && customer.FollowBy == null)
            {
                if (model.FollowBy != null)
                {
                    customer.FollowBy = model.FollowBy;
                }
                _context.Projects.Update(project);
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index", "ManageProject");
            }
            else
            {
                if (model.FollowBy != null)
                {
                    customer.FollowBy = model.FollowBy;
                }
                _context.Projects.Update(project);
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return View(model);
            }


        }

        [HttpPost]
        public IActionResult ChangeCustomerToFollowState(string employeeId, int customerId, string comment)
        {
            var count = _context.CustomerStateDescriptions.Count();
            int maxId = 1;
            if (count != 0)
            {
                maxId = _context.CustomerStateDescriptions.Max(x => x.Id) + 1;
            }

            var newRecord = new CustomerStateDescription();

            newRecord.Id = maxId;
            newRecord.EmployeeId = employeeId;
            newRecord.CustomerId = customerId;
            newRecord.CreatedAt = DateTime.Now;
            newRecord.CommentText = comment;

            _context.CustomerStateDescriptions.Add(newRecord);
            _context.SaveChanges();

            var customer = _context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
            customer.CustomerState = "متابعة";
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DateWasSent(int customerId)
        {
            var customer = _context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
            customer.CustomerState = "تم ارسال البيانات";
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return RedirectToAction("CustomerStateComment", new { customerId });
        }
        [HttpPost]
        public IActionResult RememberComment(DateTime date, string content, int customerId, string EmployeeId)
        {
            var newRecord = new RemindCustomer();
            var IfFound = _context.RemindCustomers.Where(x => x.CustomerId == customerId).FirstOrDefault();
            string messageDone = "";
            if (IfFound != null)
            {
                string message = "يوجد تذكير لهذا العميل من قبل !";
                return RedirectToAction("ErrorPage", new { message });
            }
            else
            {
                newRecord.Content = content;
                newRecord.CustomerId = customerId;
                newRecord.EmployeeId = EmployeeId;
                newRecord.Date = date.ToString();
                _context.RemindCustomers.Add(newRecord);
                _context.SaveChanges();
                messageDone = "تم اضافة تذكير خاص بهذا العميل";
            }

            return RedirectToAction("CustomerStateComment", new { customerId, messageDone });
        }


        public IActionResult ErrorPage(string message)
        {
            ViewBag.message = message;
            return View();
        }
        [HttpGet]
        public IActionResult CustomerStateComment(int customerId, string? messageDone)
        {
            var result = _context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
            if (messageDone != "")
            {
                ViewBag.RemindDone = messageDone;
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult CustomerStateComment(int customerId, string employeeId, int stateId, int commeunecationTypeId)
        {
            var newRecord = new CustomerCommentstbl();
            var maxOperationId = _context.CustomerCommentstbls.Where(x => x.CustomerId == customerId && x.StateId == stateId && x.TypeOfCommunicationId == commeunecationTypeId).Count();
            if (maxOperationId != 0)
            {
                newRecord.Id = maxOperationId + 1;
            }
            else
            {
                newRecord.Id = 1;
            }
            newRecord.CustomerId = customerId;
            newRecord.EmployeeId = employeeId;
            newRecord.StateId = stateId;
            newRecord.TypeOfCommunicationId = commeunecationTypeId;
            newRecord.date = DateTime.Now.ToString();
            _context.CustomerCommentstbls.Add(newRecord);
            _context.SaveChanges();

            if (newRecord.StateId == 1)
            {
                var result = _context.CustomerCommentstbls.Where(x => x.CustomerId == newRecord.CustomerId && x.TypeOfCommunicationId == newRecord.TypeOfCommunicationId & x.StateId == 0).ToList();
                _context.CustomerCommentstbls.RemoveRange(result);
                _context.SaveChanges();
            }

            if (newRecord.StateId == 0 && newRecord.TypeOfCommunicationId == 1)
            {
                var getCountPhoneNoAnswer = _context.CustomerCommentstbls.Where(x => x.CustomerId == newRecord.CustomerId && x.TypeOfCommunicationId == 1 && x.StateId == 0).Count();
                if (getCountPhoneNoAnswer == 3)
                {
                    var customerResult = _context.Customers.Where(x => x.Id == newRecord.CustomerId).FirstOrDefault();
                    customerResult.CustomerState = "لم يرد";
                    _context.Customers.Update(customerResult);
                    _context.SaveChanges();
                }
            }
            var customer = _context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
            return View(customer);

        }

        public List<Project> GetAllProjects()
        {
            var allProjects = _context.Projects.OrderBy(x => x.Id).AsNoTracking().ToList();
            return allProjects;
        }

        public List<CustomerStateDescription> GetAllCustomerStateDescription()
        {
            var allCustomerStateDescription = _context.CustomerStateDescriptions.OrderBy(x => x.Id).AsNoTracking().ToList();
            return allCustomerStateDescription;
        }

        public List<Customer> GetAllCustomer()
        {

            if (User.IsInRole("Admin"))
            {
                var allCustomer = _context.Customers.OrderBy(x => x.CreatedAt).AsNoTracking().ToList();
                return allCustomer;
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var allCustomer = _context.Customers.Where(x => x.FollowBy == userId).OrderBy(x => x.CreatedAt).AsNoTracking().ToList();
                return allCustomer;
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

                var result = _context.Users.Where(x => x.Id == userId).Select(x => new { FName = x.FirstName, LName = x.LastName }).FirstOrDefault();

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

        public JsonResult getCustomerByState(string state, string followBy)
        {
            var ListCustomer = new List<Customer>();
            ListCustomer = _context.Customers.Where(x => x.CustomerState == state && x.FollowBy == followBy).ToList();

            return Json(ListCustomer);
        }
    }
}
