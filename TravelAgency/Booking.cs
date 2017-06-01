using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Booking
    {
        public string TheTourName { get; set; }

        public DateTime Tourday { get; set; }

        public Passenger ThePassenger { get; set; }

    }
}