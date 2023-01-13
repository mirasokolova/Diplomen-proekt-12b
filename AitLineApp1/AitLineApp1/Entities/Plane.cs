using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitLineApp1.Entities
{
    public class Plane
    {
        public Plane()
        {
            this.Flights = new HashSet<Flight>();
        }
        public int Id { get; set; }

        public string PlaneCode { get; set; }
        public string PlaneModel { get; set; }

        public string PlaneImage { get; set; }

        public double WeightOfLagage { get; set; }

        public bool BarOnBoard { get; set; }
        public int SeatsForPassengers { get; set; }


        public ICollection<Flight> Flights { get; set; }
    }
}

