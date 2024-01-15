using AlwasataNew.Data;
using AlwasataNew.Models;
using AlwasataNew.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlwasataNew.Controllers
{

    [Authorize(Roles ="Admin")]
    public class ManageProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ManageProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string? ProjectState)
        {
            var projects = new List<ShowProjectsByStateViewModel>();

            if(ProjectState == null)
            {
                var customers = _context.Customers.Where(x => x.FollowBy == null);
                foreach (var customer in customers)
                {
                    var project = _context.Projects.Where(x => x.CustomerId == customer.Id).AsNoTracking().FirstOrDefault();
                    ShowProjectsByStateViewModel item = new ShowProjectsByStateViewModel();
                    item.CustomerId = customer.Id;
                    item.ProjectCreatedDate = project.CreatedAt.ToString();
                    item.ProjectDescription = project.Description;
                    item.CustomerName = customer.CustomerName;
                    var empName = _context.Users.Where(x => x.Id == customer.FollowBy).AsNoTracking().Select(n => new { n.FirstName, n.LastName }).FirstOrDefault();
                    if(empName !=null)
                    {
                        item.FollowBy = empName.FirstName + " " + empName.LastName;
                    }
                    else
                    {
                        item.FollowBy = "لايوجد";
                    }
                    item.ProjectState = customer.CustomerState;
                    item.ProjectId = project.Id;
                    item.CustomerComeFrom = customer.CustomerComeFrom;
                    item.ClientSource = customer.ClientSource;
                    projects.Add(item);
                }
                return View(projects);
            }
            else if(ProjectState=="متابع")
            {
                var customers = _context.Customers.Where(x => x.FollowBy != null);
                foreach (var customer in customers)
                {
                    var project = _context.Projects.Where(x => x.CustomerId == customer.Id).AsNoTracking().FirstOrDefault();
                    ShowProjectsByStateViewModel item = new ShowProjectsByStateViewModel();
                    item.CustomerId = customer.Id;
                    item.ProjectCreatedDate = project.CreatedAt.ToString();
                    item.ProjectDescription = project.Description;
                    item.CustomerName = customer.CustomerName;
                    var empName = _context.Users.Where(x => x.Id == customer.FollowBy).AsNoTracking().Select(n => new { n.FirstName, n.LastName }).FirstOrDefault();
                    item.FollowBy = empName.FirstName + " " + empName.LastName;
                    item.ProjectState = customer.CustomerState;
                    item.ProjectId = project.Id;
                    item.CustomerComeFrom = customer.CustomerComeFrom;
                    item.ClientSource = customer.ClientSource;
                    projects.Add(item);
                }
                return View(projects);
            }
            else if(ProjectState=="غير متابع")
            {
                var customers = _context.Customers.Where(x => x.FollowBy == null);
                foreach (var customer in customers)
                {
                    var project = _context.Projects.Where(x => x.CustomerId == customer.Id).AsNoTracking().FirstOrDefault();
                    ShowProjectsByStateViewModel item = new ShowProjectsByStateViewModel();
                    item.CustomerId = customer.Id;
                    item.ProjectCreatedDate = project.CreatedAt.ToString();
                    item.ProjectDescription = project.Description;
                    item.CustomerName = customer.CustomerName;
                    var empName = _context.Users.Where(x => x.Id == customer.FollowBy).AsNoTracking().Select(n => new { n.FirstName, n.LastName }).FirstOrDefault();
                    item.FollowBy = empName.FirstName + " " + empName.LastName;
                    item.ProjectState = customer.CustomerState;
                    item.ProjectId = project.Id;
                    item.CustomerComeFrom = customer.CustomerComeFrom;
                    item.ClientSource = customer.ClientSource;
                    projects.Add(item);
                }
                return View(projects);
            }
            else
            {
                var projectsList = _context.Projects.Where(x => x.IsDone == true).ToList();
                foreach (var project in projectsList)
                {
                    var customer = _context.Customers.Where(x => x.Id == project.CustomerId).AsNoTracking().FirstOrDefault();
                    
                    ShowProjectsByStateViewModel item = new ShowProjectsByStateViewModel();
                    item.CustomerId = customer.Id;
                    item.ProjectCreatedDate = project.CreatedAt.ToString();
                    item.ProjectDescription = project.Description;
                    item.CustomerName = customer.CustomerName;
                    var empName = _context.Users.Where(x => x.Id == customer.FollowBy).AsNoTracking().Select(n => new { n.FirstName, n.LastName }).FirstOrDefault();
                    item.FollowBy = empName.FirstName + " " + empName.LastName;
                    item.ProjectState = customer.CustomerState;
                    item.ProjectId = project.Id;
                    item.CustomerComeFrom = customer.CustomerComeFrom;
                    item.ClientSource = customer.ClientSource;
                    projects.Add(item);
                }
                return View(projects);
            }
            
        }

        public List<Project> GetAllProjects()
        {
            using(var dbContext = new ApplicationDbContext()) { 
            
                var allProjects = dbContext.Projects.ToList(); 
                return allProjects;
            }
        }

        public List<Customer> GetAllCustomer()
        {
            using (var dbContext = new ApplicationDbContext())
            {

                var allCustomer = dbContext.Customers.ToList();
                return allCustomer;
            }
        }

        public List<Company> GetAllCompanies()
        {
            using (var dbContext = new ApplicationDbContext())
            {

                var allCompanies = dbContext.Companies.ToList();
                return allCompanies;
            }
        }
    }
}
