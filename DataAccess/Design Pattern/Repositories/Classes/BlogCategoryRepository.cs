using DataAccess.Design_Pattern.GenericRepository;
using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
    public class BlogCategoryRepository : GenericRepsotory<BlogCategory>, IBlogCategoriesRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public BlogCategoryRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return GetAll().ToList();
        }
    }
}
