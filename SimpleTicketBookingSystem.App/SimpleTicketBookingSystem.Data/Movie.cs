using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.Data
{ 
    //⦁	Створіть клас Movie з властивостями: Title, Duration, AgeRestriction
    public class Movie : IMovie
    {
       
        public string? Title { get; set; }
        public int Duration { get; set; }
        public string? AgeRestriction { get; set; }
        public ISeats Seats { get; set; } 

        public Movie()
        {
            Seats = new Seats(); 
        }
    }
}