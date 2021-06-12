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


        #endregion



        void SaveChangesDB();
        Task<int> SaveChangesDBAsync();

    }
}
