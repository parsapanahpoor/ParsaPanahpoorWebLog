using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
   public  class AbilitiesRepository : GenericRepository.GenericRepsotory<Abilities> , IAbilitiesRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public AbilitiesRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
