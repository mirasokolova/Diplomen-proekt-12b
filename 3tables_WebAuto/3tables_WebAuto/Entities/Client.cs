using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3tables_WebAuto.Entities
{
    public class Client
    {
        public Client()
        {
            this.Purchases = new HashSet<Purchase>();
        }
         public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastNAme { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string ENG { get; set; }
        [Required]
        [MaxLength(30)]
        public string Address{ get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        
        public string Phone { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
