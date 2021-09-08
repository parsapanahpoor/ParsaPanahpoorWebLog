using DataAccess.Design_Pattern.GenericRepository;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Models.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {

        List<Project> GetAllProjects();
        void AddProject(ProjectsViewModls project, IFormFile imgBlogUp);
        void UpdateProject(Project slider, IFormFile imgBlogUp);
        Project GetPRojectById(int id);
        void DeleteProject(Project project);
        Tuple<List<Project>, int> GetProjectsForShowInLandingPage(int pageid, int take = 0);


    }
}
