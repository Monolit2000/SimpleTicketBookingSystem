using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.Interfaces
{
    public interface IDataService
    {
        public IMovies Movies { get; set; }
    }
}