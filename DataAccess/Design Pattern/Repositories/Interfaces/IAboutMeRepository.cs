using DataAccess.Design_Pattern.GenericRepository;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
    public  interface IAboutMeRepository : IGenericRepository<AboutMe>
    {

        List<AboutMe> GetAllResumes();
        void AddResume(ResumeViewModel resume);
        AboutMe GetResumeById(int id);
        void UpdateResume(AboutMe resume, IFormFile imgProductUp);
        void DeleteAboutMe(AboutMe resume);
        AboutMe GetLastResume();


    }
}
