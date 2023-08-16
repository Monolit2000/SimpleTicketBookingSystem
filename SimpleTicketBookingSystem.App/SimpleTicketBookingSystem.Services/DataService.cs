using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.Services
{
    public class DataService : IDataService
    {
        public IMovies Movies { get; set; }

        public DataService()
        {
          Movies = new Movies();
        }
    }
}