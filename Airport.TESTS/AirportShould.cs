using Airport.CORE.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace Airport.TESTS
{
    [TestFixture]
    public class AirportShould
    {
        ArrivalService arrivalService;
        ArrivalRepository arrivalRepository;

        [SetUp]
        public void TestInit()
        {
            //arrivalRepository = new ArrivalRepository();
            //arrivalService = new ArrivalService(arrivalRepository);

            //arrivalService.AddPlane(new CORE.Entities.Plane() { FlightNumber = 123, PlaneType = CORE.Enums.PlaneType.BIG, ArrivalDate = new DateTime(2020, 11, 24, 12, 0, 0) });
            //arrivalService.AddPlane(new CORE.Entities.Plane() { FlightNumber = 123, PlaneType = CORE.Enums.PlaneType.SMALL, ArrivalDate = new DateTime(2020, 10, 24, 12, 0, 0) });
            //arrivalService.AddPlane(new CORE.Entities.Plane() { FlightNumber = 123, PlaneType = CORE.Enums.PlaneType.SMALL, ArrivalDate = new DateTime(2020, 9, 24, 12, 0, 0) });
            //arrivalService.AddPlane(new CORE.Entities.Plane() { FlightNumber = 123, PlaneType = CORE.Enums.PlaneType.BIG, ArrivalDate = new DateTime(2020, 8, 24, 12, 0, 0) });
        }

        [Test]
        public void Arrival_Should()
        {
            var planes = arrivalService.GetAll();

            Assert.That(planes.Count, Is.EqualTo(4));
        }
    }
}
