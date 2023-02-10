using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership_App.Models
{
    public class CarsCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Model ")]
        public string Model { get; set; }

        [Required]
        [MaxLength(8)]
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Manifactured")]
        public string Manifactured { get; set; }

        [Display(Name = "YearOfManifacture ")]
        public DateTime YearOfManifacture { get; set; }

        [Display(Name = "Car Picture ")]
        public string Picture { get; set; }


        [Required]
        [Range(1000, 30000, ErrorMessage = "Age must be a possitive number and lower than 3000")]
        [Display(Name = "Price ")]
        public double Price { get; set; }
      
        
    }
}
