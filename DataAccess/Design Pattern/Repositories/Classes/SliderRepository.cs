using DataAccess.Design_Pattern.GenericRepository;
using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataAccess.Design_Pattern.UnitOfWork;
using DataContext.Context;
using Microsoft.AspNetCore.Http;
using Models.Entities.Sldier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utilities.Convertors;
using Utilities.Genarator;
using Utilities.Security;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
  public  class SliderRepository : GenericRepsotory<Slider>, ISldierRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public SliderRepository(ParsaPanahpoorDbContext db  ) : base(db)
        {
            _db = db;
        }

        public void AddSlider(Slider slider, IFormFile imgBlogUp)
        {
            slider.SliderImageName = "no-photo.png";  //تصویر پیشفرض

            if (imgBlogUp != null && imgBlogUp.IsImage())
            {
                slider.SliderImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", slider.SliderImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider/thumb", slider.SliderImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            Add(slider);
                

        }

        public void DeleteSldier(Slider slider)
        {

            if (slider.SliderImageName != "no-photo.png")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", slider.SliderImageName);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider/Thumb", slider.SliderImageName);
                if (File.Exists(deletethumbPath))
                {
                    File.Delete(deletethumbPath);
                }
            }
            Delete(slider);

        }

        public List<Slider> GetAllSliders()
        {
            return GetAll().ToList();
        }

        public Slider GetSldierForShow()
        {
            return GetFirstOrDefault();
        }

        public Slider GetSliderById(int id)
        {
            return GetById(id);
        }

        public void UpdateSlider(Slider slider, IFormFile imgBlogUp)
        {
            if (imgBlogUp != null && imgBlogUp.IsImage())
            {

                if (slider.SliderImageName != "no-photo.png")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", slider.SliderImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider/Thumb", slider.SliderImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }



                slider.SliderImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", slider.SliderImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider/Thumb", slider.SliderImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            Update(slider);
        }
    }
}
