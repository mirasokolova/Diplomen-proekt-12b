using CarDealership_App.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarDealership_App.Models;

namespace CarDealership_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDealership_App.Models.CarsAllViewModel> DogCreateViewModel { get; set; }
        public DbSet<CarDealership_App.Models.CarsCreateViewModel> DogAllViewModel { get; set; }
        public DbSet<CarDealership_App.Models.CarsDetailsViewModel> CarsDetailsViewModel { get; set; }
    }
}
