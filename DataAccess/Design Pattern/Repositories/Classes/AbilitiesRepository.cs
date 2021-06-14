using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddAbility(Abilities ability)
        {
            Add(ability);
        }

        public void DeleteAbility(Abilities abilities)
        {
            Delete(abilities);
        }

        public Abilities GetAbilityById(int id)
        {
            return GetById(id);
        }

        public List<Abilities> GetAllAbilities()
        {
            return GetAll().ToList();
        }

        public void UpdateAbilities(Abilities abilities)
        {
            Update(abilities);
        }
    }
}
