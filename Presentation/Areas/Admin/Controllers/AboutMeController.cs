using DataAccess.Design_Pattern.UnitOfWork;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly IUnitOfWork _context;
        public AboutMeController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Resume()
        {
            var resume = _context.aboutMeRepository.GetAllResumes();

            return View(resume);
        }
        public IActionResult Create()
        {


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResumeViewModel aboutMe)
        {
            if (ModelState.IsValid)
            {

                _context.aboutMeRepository.AddResume(aboutMe);
                _context.SaveChangesDB();

                return RedirectToAction(nameof(Resume));


            }

            return View();

        }

        public IActionResult Edit(int id , bool Delete = false )
        {

          
            var resume = _context.aboutMeRepository.GetResumeById(id);

            if (resume == null)
            {
                return NotFound();
            }

            if (Delete == true)
            {
                ViewData["Delete"] = false;
            } 

            return View(resume);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,UserName,JobAbility,Email,PhoneNumber,AvatarName,LongDescription")] AboutMe resume , IFormFile imgProductUp)
        {
            if (ModelState.IsValid)
            {
                _context.aboutMeRepository.UpdateResume(resume , imgProductUp);
                _context.SaveChangesDB();

                return RedirectToAction(nameof(Resume));
            }

            return View();
        }

        public IActionResult Delete(int id )
        {
            var resume = _context.aboutMeRepository.GetResumeById(id);
            _context.aboutMeRepository.DeleteAboutMe(resume);
            _context.SaveChangesDB();

            return RedirectToAction(nameof(Resume));
        }


    }
}
