using DataAccess.Design_Pattern.GenericRepository;
using Microsoft.AspNetCore.Http;
using Models.Entities.Sldier;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
   public interface ISldierRepository : IGenericRepository<Slider>
    {

        List<Slider> GetAllSliders();
        void AddSlider(Slider slider , IFormFile imgBlogUp);
        Slider GetSliderById(int id );
        void UpdateSlider(Slider slider, IFormFile imgBlogUp);
        void DeleteSldier(Slider slider);
        Slider GetSldierForShow();

    }
}
