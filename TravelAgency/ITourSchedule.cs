using System;
using System.Collections.Generic;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime doft, int numseat);
        List<Tour> GetToursFor(DateTime doft);
    }
}