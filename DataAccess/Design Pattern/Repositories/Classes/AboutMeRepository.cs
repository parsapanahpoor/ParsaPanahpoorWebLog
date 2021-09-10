using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataAccess.ViewModels;
using DataContext.Context;
using Microsoft.AspNetCore.Http;
using Models.Entities.AboutMe;
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
    public class AboutMeRepository : GenericRepository.GenericRepsotory<AboutMe>, IAboutMeRepository
    {

        private readonly ParsaPanahpoorDbContext _db;

        public AboutMeRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddResume(ResumeViewModel resume)
        {
            AboutMe about = new AboutMe()
            {
                UserName = resume.UserName,
                PhoneNumber = resume.PhoneNumber,
                JobAbility = resume.JobAbility,
                Email = resume.Email,
                LongDescription = resume.LongDescription


            };
            if (resume.AvatarName != null && resume.AvatarName.IsImage())
            {
                string imagePath = "";
                about.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(resume.AvatarName.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", about.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    resume.AvatarName.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar/Thumb", about.AvatarName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            Add(about);
        }

        public void DeleteAboutMe(AboutMe resume)
        {
            if (resume.AvatarName != "Defult.jpg")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", resume.AvatarName);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar/Thumb", resume.AvatarName);
                if (File.Exists(deletethumbPath))
                {
                    File.Delete(deletethumbPath);
                }
            }

            Delete(resume);
        }

        public List<AboutMe> GetAllResumes()
        {
            return GetAll().ToList();
        }

        public AboutMe GetLastResume()
        {
            return GetAll().Single();
        }

        public AboutMe GetResumeById(int id)
        {
            return GetById(id);
        }

        public void UpdateResume(AboutMe resume, IFormFile imgProductUp)
        {
            if (imgProductUp != null && imgProductUp.IsImage())
            {
                if (resume.AvatarName != "Defult.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", resume.AvatarName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar/Thumb", resume.AvatarName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }

                resume.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProductUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", resume.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgProductUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar/Thumb", resume.AvatarName);

            }

            Update(resume);

        }
    }
}
