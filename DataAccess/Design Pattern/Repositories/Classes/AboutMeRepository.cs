using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
   public class AboutMeRepository  : GenericRepository.GenericRepsotory<AboutMe> , IAboutMeRepository
    {

        private readonly ParsaPanahpoorDbContext _db;

        public AboutMeRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
