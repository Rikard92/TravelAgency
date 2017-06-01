using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class BookingSystem
    {
        public List<Booking> Bookings;
        public ITourSchedule Tourinterface;

        public BookingSystem(ITourSchedule it)
        {
            Bookings = new List<Booking>();
            Tourinterface = it;
        }

        public void CreateBooking(string TourName, DateTime TourDate, Passenger p)
        {
            List<Tour> ListT = Tourinterface.GetToursFor(TourDate);

            Tour FoundTour = ListT.FirstOrDefault();
            if (FoundTour == null)
            {
                throw new NoTourExists();
            }

            if (FoundTour.numberofseats<=Bookings.Count)
            {
                throw new NoMoreSeatsException();
            }

            Bookings.Add(new Booking()
            {
                ThePassenger = p,
                TheTourName = TourName,
                Tourday = TourDate,
            });
        }

        public List<Booking> GetBookingsFor(Passenger pas)
        {
            List<Booking> bokingpas = new List<Booking>();

            foreach (Booking b in Bookings)
            {
                if (b.ThePassenger.Equals(pas))
                {
                    bokingpas.Add(b);
                }
            }

            return bokingpas;
        }
    }
}