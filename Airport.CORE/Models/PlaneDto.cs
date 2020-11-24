using Airport.CORE.Enums;
using System;

namespace Airport.CORE.Models
{
    public class PlaneDto
    {
        public int FlightNumber { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime ArrivalDate { get; set; }
    }
}
