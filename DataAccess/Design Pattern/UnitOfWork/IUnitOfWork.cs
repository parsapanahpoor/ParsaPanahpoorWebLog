using DataAccess.Design_Pattern.Repositories.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Design_Pattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        #region Repositories

        BlogCategoryRepository BlogCategory { get; }
        SliderRepository sliderRepository { get; }
        AboutMeRepository aboutMeRepository { get; }
        AbilitiesRepository abilitiesRepository { get; }
        BanerRepository BanerRepository { get; }
        ProjectRepository ProjectRepository { get; }



        #endregion



        void SaveChangesDB();
        Task<int> SaveChangesDBAsync();

    }
}
