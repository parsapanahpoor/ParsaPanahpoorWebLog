﻿using DataContext.Context;
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
        }

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
    }
}