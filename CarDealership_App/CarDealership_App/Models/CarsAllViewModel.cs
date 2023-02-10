using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership_App.Models
{
    public class CarsAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Model ")]
        public string Model { get; set; }

        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; }


        [Display(Name = "Manifactured")]
        public string Manifactured { get; set; }


        [Display(Name = "YearOfManifacture ")]
        public DateTime YearOfManifacture { get; set; }

        [Display(Name = "Price ")]
        public double Price { get; set; }


        [Display(Name = "Car Picture")]
        public string Picture { get; set; }
    }
}
