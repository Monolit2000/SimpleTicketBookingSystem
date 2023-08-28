using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.Interfaces
{
    /// <summary>
    ///  movie storage interface
    /// </summary>
    public interface IDataService
    {
        public IMovies Movies { get; set; }
    }
}