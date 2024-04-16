using AlwasataNew.Models;
using AlwasataNew.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlwasataNew.Controllers
{
    
    public class QuestionnaireController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult InteriorDesign()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult InteriorDesign(InteriorDesignQuestionnaireVM model)
        {

            return View();
        }
    }
}
