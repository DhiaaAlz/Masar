using Microsoft.AspNetCore.Mvc;

namespace AlwasataNew.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
