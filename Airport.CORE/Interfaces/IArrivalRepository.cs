using Airport.CORE.Entities;
using System.Collections.Generic;

namespace Airport.CORE.Interfaces
{
    public interface IArrivalRepository
    {
        void AddPlane(Plane plane);
        IEnumerable<Plane> GetAll();
        IEnumerable<Plane> GetAllRecent(int seconds);
        Plane GetPlane(int flightNumber);
    }
}
