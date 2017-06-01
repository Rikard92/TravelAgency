using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours;
        public void CreateTour(string name, DateTime doft, int numseat)
        {
            throw new NotImplementedException();

            Tour newt = new Tour()
            {
                Name = name,
                TourDate = doft,
                numberofseats = numseat
            };

            if (GetToursFor(doft).Count == 3)
            {
                throw new TourAllocationException();
            }

            Tours.Add(newt);

        }

        public List<Tour> GetToursFor(DateTime doft)
        {

            List<Tour> retlist = new List<Tour>();

            foreach (var T in Tours)
            {
                if (T.TourDate.Year.Equals(doft.Year) && T.TourDate.Month.Equals(doft.Month) && T.TourDate.Day.Equals(doft.Day))
                {
                    retlist.Add(T);
                }
            }

            return retlist;
        }

        
    }
}
