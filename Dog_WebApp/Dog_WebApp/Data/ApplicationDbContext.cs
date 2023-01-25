using Dog_WebApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dog_WebApp.Models;

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
    }
}
