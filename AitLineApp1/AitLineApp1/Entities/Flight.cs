using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AitLineApp1.Entities
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        //public int FlightId { get; set; }
        //[Required]
        //[MaxLength(30)]
        public string TakingOffDestination { get; set; }

        [Required]
        [MaxLength(30)]
        public string LandingDestination { get; set; }
        [Required]
        public DateTime TakingOff { get; set; }

        [Required]
        public DateTime Landing { get; set; }

        public double TicketPrice { get; set; }

        public double Discount { get; set; }
        [ForeignKey("Plane")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}

