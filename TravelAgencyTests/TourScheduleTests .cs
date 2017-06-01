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
    public class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void TourScheduleSetup()
        {
            sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            //Arrange
            

            //Act
            sut.CreateTour("New years day safari",new DateTime(2013, 1, 1, 10, 15, 0), 20);
            List<Tour> lt = sut.GetToursFor(new DateTime(2013, 1, 1));


            
            //Assert
            Assert.AreEqual("New years day safari", lt[0].Name);
            Assert.AreEqual(20, lt[0].numberofseats);
            Assert.AreEqual(1,lt.Count);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            //Arrange
            
            //Act
            sut.CreateTour("New time climing", new DateTime(2013, 12, 21, 10, 15, 0), 30);
            sut.CreateTour("New hour riding", new DateTime(2014, 10, 11, 10, 15, 0), 60);
            sut.CreateTour("New day skating", new DateTime(2015, 8, 29, 10, 15, 0), 15);

            List<Tour> lt = sut.GetToursFor(new DateTime(2013, 12, 21));

            //Assert
            Assert.AreEqual(1, lt.Count);
            Assert.AreEqual("New time climing", lt[0].Name);
            Assert.AreEqual(30, lt[0].numberofseats);
        }

        [Test]
        public void CanonlyHAveThreeADay()
        {
            //Arrange

            //Act
            sut.CreateTour("New time climing", new DateTime(2013, 12, 21, 10, 15, 0), 30);
            sut.CreateTour("New hour riding", new DateTime(2013, 12, 21, 10, 15, 0), 60);
            sut.CreateTour("New day skating", new DateTime(2013, 12, 21, 10, 15, 0), 15);

            Assert.Throws<TourAllocationException>(() => sut.CreateTour("fourth T", new DateTime(2013, 12, 21, 10, 15, 0), 30));
        }
    }
}
