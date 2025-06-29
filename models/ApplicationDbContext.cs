using Microsoft.EntityFrameworkCore;
using final_project.models;
using final_project.models.DTOs;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace final_project.models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Donor> Donors { get; set; }    
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Gift> Gifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
