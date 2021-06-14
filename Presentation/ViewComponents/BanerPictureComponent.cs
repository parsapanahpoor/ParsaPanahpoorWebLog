using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaPanahpoor.WebSite.ViewComponents
{
    public class BanerPictureComponent : ViewComponent
    {
        private readonly IUnitOfWork _context;
        public BanerPictureComponent(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            return await Task.FromResult((IViewComponentResult)View("BanerPictureComponent", _context.BanerRepository.GetTheLastestBaner()));

        }
    }
}
