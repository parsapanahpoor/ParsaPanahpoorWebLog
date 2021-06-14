using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Microsoft.AspNetCore.Http;
using Models.Entities.Sldier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utilities.Genarator;
using Utilities.Security;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
    public class BanerRepository : GenericRepository.GenericRepsotory<Baner>, IBanerRepository
    {

        private readonly ParsaPanahpoorDbContext _db;

        public BanerRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }


        public void AddBaner(Baner baner, IFormFile imgBlogUp)
        {
            baner.BanerImageName = "no-photo.png";  //تصویر پیشفرض

            if (imgBlogUp != null && imgBlogUp.IsImage())
            {
                baner.BanerImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", baner.BanerImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }


            }

            Add(baner);
        }

        public void DeletBaner(Baner baner)
        {
            if (baner.BanerImageName != "no-photo.png")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", baner.BanerImageName);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }


            }


            Delete(baner);
        }

        public List<Baner> GetAllBaners()
        {
            return GetAll().ToList();
        }

        public Baner GetBanerById(int id)
        {
            return GetById(id);
        }

        public Baner GetTheLastestBaner()
        {
            return GetAll().FirstOrDefault();
        }

        public void UpdateBaner(Baner baner, IFormFile imgBlogUp)
        {
            if (imgBlogUp != null && imgBlogUp.IsImage())
            {

                if (baner.BanerImageName != "no-photo.png")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", baner.BanerImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }



                baner.BanerImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", baner.BanerImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

            }
            Update(baner);
        }
    }
}
