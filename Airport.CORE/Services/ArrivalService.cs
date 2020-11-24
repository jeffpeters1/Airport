using Airport.CORE.Entities;
using Airport.CORE.Interfaces;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airport.CORE.Services
{
    public class ArrivalService : IArrivalService
    {
        private readonly IArrivalRepository _arrivalRepository;
        private readonly IConfiguration _config;
        private int _landingTime;

        public ArrivalService(IArrivalRepository arrivalRepository, IConfiguration config)
        {
            _arrivalRepository = arrivalRepository;
            _config = config;
            _landingTime =  int.Parse(_config.GetSection("LandingTime").Value);   // configured in appsettings.json
        }

        public bool IsArrivalPossible(Plane plane)
        {
            bool IsPossible = true;
            
            LogAttemptedArrival(plane);

            var recentArrivals = _arrivalRepository.GetAllRecent(_landingTime);

            // Check if any planes landed within the configured landing time
            if (recentArrivals.Any())
            {
                var big = recentArrivals.Where(p => p.PlaneType == Enums.PlaneType.BIG).Count();
                var small = recentArrivals.Where(p => p.PlaneType == Enums.PlaneType.SMALL).Count();

                // Check if recent arrived plane is either a BIG plane or there have already been 2 SMALL planes landed
                if (big >= 1 || small >= 2)
                    IsPossible = false;
            }

            return IsPossible;
        }

        public IEnumerable<Plane> GetAll()
        {
            return _arrivalRepository.GetAll();
        }

        public Plane GetPlane(int flightNumber)
        {
            if (flightNumber == 0)
            {
                throw new ArgumentNullException(nameof(flightNumber));
            }

            return _arrivalRepository.GetPlane(flightNumber);
        }

        public void AddPlane(Plane plane)
        {
            _arrivalRepository.AddPlane(plane);
        }

        private static void LogAttemptedArrival(Plane plane)
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace($"Attempted Arrival : {plane.FlightNumber} at {plane.ArrivalDate}");
        }
    }
}
