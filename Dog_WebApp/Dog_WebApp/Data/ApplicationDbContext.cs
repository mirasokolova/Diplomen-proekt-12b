using Dog_WebApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dog_WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            Database.EnsureCreated();

        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Dog_WebApp.Models.DogCreateViewModel> DogCreateViewModel { get; set; }
        public DbSet<Dog_WebApp.Models.DogAllViewModel> DogAllViewModel { get; set; }
        public DbSet<Dog_WebApp.Models.DogDetailsViewModel> DogDetailsViewModel { get; set; }
    }
}
