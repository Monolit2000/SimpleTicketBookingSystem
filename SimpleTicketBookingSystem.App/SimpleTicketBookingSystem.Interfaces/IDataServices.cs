using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.Interfaces
{
    /// <summary>
    ///  movie storage interface
    /// </summary>
    public interface IDataService
    {
        public IMovies Movies { get; set; }

        public void Reservation(IReservation reservation);

        public bool Write(string jsonPath);
    }
}