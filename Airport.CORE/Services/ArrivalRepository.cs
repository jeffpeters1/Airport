using Airport.CORE.Entities;
using Airport.CORE.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airport.CORE.Services
{
    public class ArrivalRepository : IArrivalRepository
    {
        // Data of planes that have arrived is stored in the cache
        private readonly IMemoryCache _cache;

        private readonly string arrivalsList = "arrivalsList";

        public ArrivalRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void AddPlane(Plane plane)
        {
            var arrivals = GetArrivalsList();

            arrivals.Add(plane);

            _cache.Set(arrivalsList, arrivals);
        }

        public IEnumerable<Plane> GetAll()
        {
            var arrivals = GetArrivalsList();

            return arrivals;
        }

        public IEnumerable<Plane> GetAllRecent(int seconds)
        {
            var arrivals = GetArrivalsList();

            return arrivals.Where(p => p.ArrivalDate.AddSeconds(seconds) > DateTime.Now) ;
        }

        public Plane GetPlane(int flightNumber)
        {
            var arrivals = GetArrivalsList();

            if (flightNumber == 0)
            {
                throw new ArgumentNullException(nameof(flightNumber));
            }

            return arrivals.FirstOrDefault(p => p.FlightNumber == flightNumber);
        }

        //Cache
        private List<Plane> GetArrivalsList()
        {
            // If exists already, get list from cache...
            if (_cache.TryGetValue(arrivalsList, out List<Plane> arrivals)) return arrivals;

            //Otherwise, create new list
            return new List<Plane>();
        }
    }
}
