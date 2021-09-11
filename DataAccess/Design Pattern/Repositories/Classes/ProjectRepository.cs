using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataAccess.ViewModels;
using DataContext.Context;
using Microsoft.AspNetCore.Http;
using Models.Entities.Projects;
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
    public class ProjectRepository : GenericRepository.GenericRepsotory<Project>, IProjectRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public ProjectRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddProject(ProjectsViewModls project, IFormFile imgBlogUp)
        {
            project.ProductImageName = "no-photo.png";  //تصویر پیشفرض

            if (imgBlogUp != null && imgBlogUp.IsImage())
            {
                project.ProductImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects", project.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects/thumb", project.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 600);
            }

            Project pro = new Project()
            {
                ProductImageName = project.ProductImageName,
                ProjectTitle = project.ProjectTitle,
                Tags = project.Tags,
                CreateDate = project.CreateDate,
                LongDescription = project.LongDescription
            };

            Add(pro);
        }

        public void DeleteProject(Project project)
        {
            if (project.ProductImageName != "no-photo.png")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects", project.ProductImageName);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects/thumb", project.ProductImageName);
                if (File.Exists(deletethumbPath))
                {
                    File.Delete(deletethumbPath);
                }
            }

            Delete(project);
        }

        public List<Project> GetAllProjects()
        {
            return GetAll().ToList();
        }

        public Project GetPRojectById(int id)
        {
            return GetById(id);
        }

        public Tuple<List<Project>, int> GetProjectsForShowInLandingPage(int pageid, int take = 0)
        {
            if (take == 0) take = 8;

            var projects = GetAll();


            int skip = (pageid - 1) * take;
            int pageCount = (projects.Count() / take);

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = projects.Skip(skip).Take(take).ToList();


            return Tuple.Create(query, pageCount);
        }

        public void UpdateProject(Project project, IFormFile imgBlogUp)
        {
            if (imgBlogUp != null && imgBlogUp.IsImage())
            {
                if (project.ProductImageName != "no-photo.png")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects", project.ProductImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects/thumb", project.ProductImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }

                project.ProductImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgBlogUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects", project.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBlogUp.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Projects/thumb", project.ProductImageName);
                imgResizer.Image_resize(imagePath, thumbPath, 600);

            }

            Update(project);
        }

    }
}
