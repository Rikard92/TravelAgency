using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule : ITourSchedule
    {
        private List<Tour> LoT;

        public TourSchedule()
        {
            LoT=new List<Tour>();
        }

        public void CreateTour(string name, DateTime doft, int numseat)
        {
             Tour theT = new Tour()
             {
                 Name = name,
                 TourDate = doft,
                 numberofseats = numseat
             };

            if (GetToursFor(doft).Count==3)
            {
                throw new TourAllocationException();
            }

            LoT.Add(theT);
            
        }

        public List<Tour> GetToursFor(DateTime doft)
        {
            List<Tour> retlist = new List<Tour>();

            foreach (var T in LoT)
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
