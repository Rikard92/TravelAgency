using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub TourScheduleStub;

        private BookingSystem sut;

        [SetUp]
        public void BookingSystemSetUp()
        {
            TourScheduleStub = new TourScheduleStub();
            

            sut = new BookingSystem(TourScheduleStub);
        }

        [Test]
        public void CanCreateBooking()
        {
            TourScheduleStub.Tours = new List<Tour>()
            {
                new Tour()
                {
                    TourDate = new DateTime(2013, 12, 21, 10, 15, 0),
                    numberofseats = 1,
                    Name = "Doing stuf"
                }
            };
            var pas = new Passenger()
            {
                FirstName= "Rikard",
                LastName = "Persson"
            };

            sut.CreateBooking("Doing stuf", new DateTime(2013, 12, 21, 10, 15, 0), pas);

            List<Booking> thebooking = sut.GetBookingsFor(pas);

            Assert.AreEqual(1, thebooking.Count);
            Assert.AreEqual("Doing stuf", thebooking[0].TheTourName);
            Assert.AreEqual(pas, thebooking[0].ThePassenger);


        }

        [Test]
        public void CanCreateBooking2()
        {
            TourScheduleStub.Tours = new List<Tour>()
            {
            };
            var pas = new Passenger()
            {
                FirstName = "Rikard",
                LastName = "Persson"
            };

            //sut.CreateBooking("Doing stuf", new DateTime(2013, 12, 21, 10, 15, 0), pas);

            //List<Booking> thebooking = sut.GetBookingsFor(pas);

            //Assert.AreEqual(1, thebooking.Count);
            //Assert.AreEqual("Doing stuf", thebooking[0].TheTourName);
            //Assert.AreEqual(pas, thebooking[0].ThePassenger);
            Assert.Throws<NoTourExists>(() =>
            {
                sut.CreateBooking("Doing stuf", new DateTime(2013, 12, 21, 10, 15, 0), pas);
            }) ;


        }

        [Test]
        public void CanCreateBooking3()
        {
            TourScheduleStub.Tours = new List<Tour>()
            {
                new Tour()
                {
                    TourDate = new DateTime(2013, 12, 21, 10, 15, 0),
                    numberofseats = 1,
                    Name = "Doing stuf"
                }
            };
            var pas = new Passenger()
            {
                FirstName = "Rikard",
                LastName = "Persson"
            };

            sut.CreateBooking("Doing stuf", new DateTime(2013, 12, 21, 10, 15, 0), pas);

            var pas2 = new Passenger()
            {
                FirstName = "Rikard",
                LastName = "Persson"
            };

            //sut.CreateBooking("Doing stuf", new DateTime(2013, 12, 21, 10, 15, 0), pas2);

            //List<Booking> thebooking = sut.GetBookingsFor(pas);

            //Assert.AreEqual(1, thebooking.Count);
            //Assert.AreEqual("Doing stuf", thebooking[0].TheTourName);
            //Assert.AreEqual(pas, thebooking[0].ThePassenger);

            Assert.Throws<NoMoreSeatsException>(() =>
            {
                sut.CreateBooking("Doing stuf", new DateTime(2013, 12, 21, 10, 15, 0), pas2);
            });
        }
    }
}
