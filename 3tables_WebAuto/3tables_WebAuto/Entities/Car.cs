using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3tables_WebAuto.Entities
{
    public class Car
    {
        public Car()
        {
            this.Purchases = new HashSet<Purchase>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string RegNumber { get; set; }
        [Required]
       
        public string Marka { get; set; }
        
        public string Picture { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        [Required]
        
        public string Year { get; set; }
        [Required]
        

        public string Price { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
