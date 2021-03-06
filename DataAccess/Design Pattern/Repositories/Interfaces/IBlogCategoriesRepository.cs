using DataAccess.Design_Pattern.GenericRepository;
using Models.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
   public interface IBlogCategoriesRepository : IGenericRepository<BlogCategory>
    {

        List<BlogCategory> GetAllBlogCategories();
        void AddBlogCategory(BlogCategory blogCategory);
        BlogCategory GetBlogCategoryById(int id );
        void UpdateBlogCategroy(BlogCategory blogCategory , int id);

    }
}
