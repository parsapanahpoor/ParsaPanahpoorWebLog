using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.Sldier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BanerController : Controller
    {
        private readonly IUnitOfWork _context;
        public BanerController(IUnitOfWork context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.BanerRepository.GetAllBaners());
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Baner baner, IFormFile imgBlogUp)
        {
            if (ModelState.IsValid)
            {
                _context.BanerRepository.AddBaner(baner, imgBlogUp);
                _context.SaveChangesDB();

                return Redirect("/Admin/Baner/Index?Create=true");
            }
            return View(baner);
        }

        public IActionResult Edit(int? id, bool Delete = false)
        {


            var slider = _context.BanerRepository.GetBanerById((int)id);
            if (slider == null)
            {
                return NotFound();
            }
            if (Delete == true)
            {
                ViewData["Delete"] = true;
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Baner baner, IFormFile imgBlogUp)
        {
            {
                if (id != baner.BanerId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {


                    _context.BanerRepository.UpdateBaner(baner, imgBlogUp);
                    _context.SaveChangesDB();

                    return Redirect("/Admin/Baner/Index?Edit=true");
                }
                return View(baner);
            }
        }

        public IActionResult Delete(int id)
        {
            var slider = _context.BanerRepository.GetBanerById(id);
            _context.BanerRepository.DeletBaner(slider);
            _context.SaveChangesDB();

            return RedirectToAction(nameof(Index));
        }
    }
}

