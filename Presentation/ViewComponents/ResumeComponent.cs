using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaPanahpoor.WebSite.ViewComponents
{
    public class ResumeComponent : ViewComponent
    {
        private readonly IUnitOfWork _context;
        public ResumeComponent(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["Ability"] = _context.abilitiesRepository.GetAllAbilities();

            return await Task.FromResult((IViewComponentResult)View("ResumeComponent", _context.aboutMeRepository.GetLastResume()));
        }
    }
}
