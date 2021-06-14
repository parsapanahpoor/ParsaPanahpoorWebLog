using DataAccess.Design_Pattern.Repositories.Classes;
using DataContext.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Design_Pattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParsaPanahpoorDbContext _db;
        public UnitOfWork(ParsaPanahpoorDbContext db)
        {
            _db = db;
            BlogCategory = new BlogCategoryRepository(_db);
            sliderRepository = new SliderRepository(_db);
            aboutMeRepository = new AboutMeRepository(_db);
            abilitiesRepository = new AbilitiesRepository(_db);
            BanerRepository = new BanerRepository(_db);
        }


        #region Repositories


        public BlogCategoryRepository BlogCategory { get; private set; }
        public SliderRepository sliderRepository { get; private set; }
        public AboutMeRepository aboutMeRepository { get; private set; }
        public AbilitiesRepository abilitiesRepository { get; private set; }
        public BanerRepository BanerRepository { get; private set; }



        #endregion


        #region Implement

        public void SaveChangesDB()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveChangesDBAsync()
        {
            return _db.SaveChangesAsync();
        }

        #endregion

        #region Dispose

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
