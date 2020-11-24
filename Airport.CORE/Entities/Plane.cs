using Airport.CORE.Enums;
using System;

namespace Airport.CORE.Entities
{
    public class Plane
    {
        public int FlightNumber { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime ArrivalDate { get; set; }
    }
}
