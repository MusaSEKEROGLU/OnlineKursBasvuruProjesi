using KursBasvuruCoreMvc.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KursBasvuruCoreMvc.WebUI.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }

        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Gevenlik
        public IActionResult Apply([FromForm] Candidate model)
        {
            //bir email bir defa kayıt yapabilir
            if (Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already an application for you.");
            }    
            //Validations ları uygula
            if (ModelState.IsValid)
            {
                Repository.Add(model);
                return View("Feedback", model);
            }
            return View();
        }
    }
}
