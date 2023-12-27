using AlwasataNew.Data;
using AlwasataNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlwasataNew.Controllers
{

    [Authorize(Roles ="Admin")]
    public class ManageProjectController : Controller
    {
        public IActionResult Index()
        {
            using(var dbContext = new ApplicationDbContext())
            {
                var allProjects = dbContext.Projects.ToList();
                return View(allProjects);
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
