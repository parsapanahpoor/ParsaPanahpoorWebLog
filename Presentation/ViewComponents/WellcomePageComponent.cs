using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewComponents
{
    public class WellcomePageComponent : ViewComponent
    {
        private readonly IUnitOfWork _context;
        public WellcomePageComponent(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            return await Task.FromResult((IViewComponentResult)View("WellcomePageComponent", _context.sliderRepository.GetSldierForShow()));

        }
    }
}
