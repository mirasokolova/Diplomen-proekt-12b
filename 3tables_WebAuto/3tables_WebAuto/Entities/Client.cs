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
            this.Purchase = new HashSet<Purchase>();
        }
         public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastNAme { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstNAme { get; set; }
    }
}
