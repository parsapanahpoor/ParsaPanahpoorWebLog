using DataAccess.Design_Pattern.GenericRepository;
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
    public  interface IAboutMeRepository : IGenericRepository<AboutMe>
    {
    }
}
