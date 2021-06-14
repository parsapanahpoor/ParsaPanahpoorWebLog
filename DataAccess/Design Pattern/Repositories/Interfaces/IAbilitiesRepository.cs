
using Models.Entities.AboutMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
   public  interface IAbilitiesRepository : GenericRepository.IGenericRepository<Abilities>
    {

        List<Abilities> GetAllAbilities();
        void AddAbility(Abilities ability);
        Abilities GetAbilityById(int id );
        void UpdateAbilities(Abilities abilities );
        void DeleteAbility(Abilities abilities);

    }
}
