using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership_App.Entities
{
    public class Car
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string RegNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string Manifactured { get; set; }
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        public string Picture { get; set; }

        public DateTime YearOfManifacture { get; set; }
        [Required]
        [Range(1000,30000)]
        public double Price { get; set; }

    }
}
