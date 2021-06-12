using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContext.Context
{
   public class ParsaPanahpoorDbContext : IdentityDbContext
    {

        public ParsaPanahpoorDbContext(DbContextOptions<ParsaPanahpoorDbContext> options)
            : base(options)
        {

        }

        #region Blog
       public DbSet<Models.Entities.Blog.Blog> Blogs { get; set; }
        public DbSet<Models.Entities.Blog.BlogCategory> blogCategories { get; set; }
        public DbSet<Models.Entities.Blog.BlogSelectedCategory> blogSelectedCategories { get; set; }

        #endregion
 



    }
}
