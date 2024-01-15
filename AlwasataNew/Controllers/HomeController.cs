using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AlwasataNew.Models;
using Microsoft.AspNetCore.Authorization;
using AlwasataNew.Data;
using AlwasataNew.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlwasataNew.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            using (var dbContext = new ApplicationDbContext())
            {

                if (User.IsInRole("Admin"))
                {
                    var users = new List<ApplicationUser>();
                    var markterPrivalageId = dbContext.Roles.Where(x=>x.Name== "Marketer").Select(x=>x.Id).FirstOrDefault();
                    var usersMarktersId= dbContext.UserRoles.Where(x=>x.RoleId==markterPrivalageId).Select(x=>x.UserId).ToList();
                    return View(usersMarktersId);
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    List<string> users=new List<string>();
                    users.Add(userId);
                    return View(users);
                }

            }
        }

        public IActionResult Card()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

