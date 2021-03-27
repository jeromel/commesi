using commesi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commesi.Controllers
{
    public class CommeSiController : Controller
    {
        private readonly IAichaService aichaService;

        public CommeSiController(IAichaService aichaService)
        {
            this.aichaService = aichaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/")]
        public IActionResult Start()
        {
            var previousSentence = aichaService.GetDocumentByPreviousSentence("Comme si");
            IActionResult result = View("_ViewAichaYouTube", previousSentence);

            return result;
        }

        [HttpGet]
        public IActionResult Aicha(string ecouteMoi)
        {
            IActionResult result;

            if (false == String.IsNullOrEmpty(ecouteMoi))
            {
                var previousSentence = aichaService.GetDocumentByPreviousSentence(ecouteMoi);
                result = View("_ViewAichaYouTube", previousSentence);
            }
            else
            {
                result = RedirectToAction("Index");
            }

            return result;
        }
    }
}
