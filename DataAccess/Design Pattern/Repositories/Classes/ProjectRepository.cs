using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
    public class ProjectRepository : GenericRepository.GenericRepsotory<Project>, IProjectRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public ProjectRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
