using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Service
{
    /// <summary>
    /// movie storage service
    /// </summary>
    public class DataService : IDataService
    {
        public IMovies Movies { get; set; }

       // public Reservation
        public DataService()
        {
            Movies = new Movies();
        }

        public void AddList()
        {

        }

        public void makeTiket(List<List<ISeat>> seats)
        {
            foreach (var innerList in seats)
            {
                foreach (var seat in innerList)
                {

                    if (seat.IsAvailable is false)
                    {

                    }

                }
            }
        }

    }
}
