﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_WebApp.Models
{
    public class DogDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Breed")]
        public string Breed { get; set; }
        [Display(Name = "Dog Picture")]
        public string Image { get; set; }
    }

}
