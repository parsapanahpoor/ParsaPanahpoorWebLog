using DataAccess.Design_Pattern.GenericRepository;
using Microsoft.AspNetCore.Http;
using Models.Entities.Sldier;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
    public interface IBanerRepository : IGenericRepository<Baner>
    {

        List<Baner> GetAllBaners();
        void AddBaner(Baner baner, IFormFile imgBlogUp);
        Baner GetBanerById(int id);
        void UpdateBaner(Baner baner, IFormFile imgBlogUp);
        void DeletBaner(Baner baner);
        Baner GetTheLastestBaner();


    }
}
