using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Data
{
    public class Reservation
    {
        public Screening Screening { get; set; }
        public ISeat? Seat { get; set; }
        public string CustomerName { get; set; }

        public Reservation(IMovie movie, ISeat seat, string customerName)
        {
            CustomerName = customerName;
            Screening = new Screening(movie);
            Seat = seat;
            Seat.IsAvailable = false;
        }


      
    }
}
