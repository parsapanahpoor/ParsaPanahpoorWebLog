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

        public void AddBlogCategory(BlogCategory blogCategory)
        {
            BlogCategory blog = new BlogCategory()
            { 
                ParentId = blogCategory.ParentId,
                CategoryTitle = blogCategory.CategoryTitle,
                IsDelete = false,

            
            
            };


            Add(blog);
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return GetAll().ToList();
        }

        public BlogCategory GetBlogCategoryById(int id)
        {
            return GetById(id);
        }

        public void UpdateBlogCategroy(BlogCategory blogCategory , int id )
        {
            var category = GetBlogCategoryById(id);

            category.CategoryTitle = blogCategory.CategoryTitle;

            Update(category);
            _db.SaveChanges();

            
        }
    }
}
