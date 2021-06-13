using DataAccess.Design_Pattern.GenericRepository;
using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.Sldier;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
  public  class SliderRepository : GenericRepsotory<Slider>, ISldierRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public SliderRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
