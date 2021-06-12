using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Design_Pattern.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {

        #region Repositories



        #endregion



        void SaveChangesDB();
        Task<int> SaveChangesDBAsync();

    }
}
