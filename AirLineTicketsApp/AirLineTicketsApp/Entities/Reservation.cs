using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int NumberOfTickets { get; set; }
        [ForeignKey("Flight")]
        [Required]
        public int FlightId { get; set; }
        public Flight Flight{ get; set; }

        [ForeignKey("Client")]
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public DateTime DatePurchase { get; set; }
      
    }
}
