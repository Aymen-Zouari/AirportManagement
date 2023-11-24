using System;
using System.Collections.Generic;
using System.Linq;
using AM.ApplicationCore.Domain;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane
    {
        //public void Add(Plane p);
        //public void save();
        //public IList<Plane> GetAll();
        //public List<Passenger> GetPassenger(Plane plane);
        public IList<IGrouping<int, Flight>> GetFlights(int n);
        public bool IsAvailable(int n, Flight flight);
    }
}
