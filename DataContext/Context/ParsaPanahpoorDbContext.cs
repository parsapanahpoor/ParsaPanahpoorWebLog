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

        public DbSet<Models.Entities.Blog.Blog> Blogs { get; set; }




    }
}
