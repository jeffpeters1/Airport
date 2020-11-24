using Airport.CORE.Entities;
using System.Collections.Generic;

namespace Airport.CORE.Interfaces
{
    public interface IArrivalService
    {
        bool IsArrivalPossible(Plane plane);
        Plane GetPlane(int id);
        IEnumerable<Plane> GetAll();
        void AddPlane(Plane plane);
    }
}
