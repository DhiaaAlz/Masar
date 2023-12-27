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
            

            using (var DbContext = new ApplicationDbContext())
            {

                if (User.IsInRole("Admin"))
                {

                    var allUser = DbContext.Users.ToList();

                    return View(allUser);
                }
                else
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var result = DbContext.Users.Where(x => x.Id == userId).ToList();

                    //string EmployeeName = result.FName + " " + result.LName;

                    //var user = DbContext.Users.Where(x => x.FirstName == result.FName && x.LastName == result.LName).ToList();
                    
                    return View(result);
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

