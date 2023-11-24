using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AM.ApplicationCore.Domain;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        //private IGenericRepository<Plane> genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        /*public void Add(Plane p)
        {
            genericRepository.Add(p);
        }

        public IList<Plane> GetAll()
        {   
            return genericRepository.GetAll().ToList();
        }

        public void save()
        {
            genericRepository.SubmitChanges();
        }

        

        public ServicePlane(IGenericRepository<Plane> genericRepository)
        {
            this.genericRepository = genericRepository;
        }*/

        public ServicePlane(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*public void Add(Plane p)
        {
            _unitOfWork.Repository<Plane>().Add(p);
        }

        public IList<Plane> GetAll()
        {
            return _unitOfWork.Repository<Plane>().GetAll().ToList();
        }

        public void save()
        {
            _unitOfWork.Save();
        }*/
        public IList<Passenger> GetPassenger(Plane plane)
        {
            var listPassenger = GetById(plane.PlaneId).Flights.SelectMany(f=>f.Tickets).Select(t=>t.Passenger);
            return listPassenger.ToList();
        }

        public IList<IGrouping<int,Flight>> GetFlights(int n)
        {
            var listFlight = GetMany()
                .OrderByDescending(p=>p.PlaneId)
                .Take(n)
                .SelectMany(p=>p.Flights)
                .OrderBy(f=>f.FlightDate)
                .GroupBy(f=>f.Plane.PlaneId)
                .ToList();
            return listFlight;
        }
        public bool IsAvailable(int n, Flight flight)
        {
            int capacity=Get(p=>p.Flights.Contains(flight)==true).Capacity;
            int nbr_tickets=flight.Tickets.Count();

            return capacity>=nbr_tickets+n;
        }
    }
}
