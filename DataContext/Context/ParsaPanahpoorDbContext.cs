using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.AboutMe;
using Models.Entities.Sldier;
using Models.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataContext.Context
{
   public class ParsaPanahpoorDbContext : IdentityDbContext<User>
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

        #region Slider

        public DbSet<Slider> sliders { get; set; }
        public DbSet<Baner> baners { get; set; }

        #endregion

        #region AboutMe

        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<Abilities> abilities { get; set; }

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;



            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);

            


            base.OnModelCreating(modelBuilder);
        }

        #endregion


    }
}
