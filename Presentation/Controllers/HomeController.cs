using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaPanahpoor.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _context;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork context)
        {
            _logger = logger;
            _context = context;
        }

        //Welcome Page
        public IActionResult Index()
        {
            return View();
        }


        [Route("/Home")]
        public IActionResult Home(bool MessageSend = false)
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/MyImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }

            var url = $"{"/MyImages/"}{fileName}";

            return Json(new { uploaded = true, url });
        }
    }
}
