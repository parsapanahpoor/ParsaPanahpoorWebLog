using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaPanahpoor.WebSite.ViewComponents
{
    public class ProjectsComponent : ViewComponent
    {
        private readonly IUnitOfWork _context;
        public ProjectsComponent(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int pageId = 1)
        {
            ViewBag.pageId = pageId;


            return await Task.FromResult((IViewComponentResult)View("ProjectsComponent", _context.ProjectRepository.GetProjectsForShowInLandingPage(pageId, 8)));

        }
    }
}
