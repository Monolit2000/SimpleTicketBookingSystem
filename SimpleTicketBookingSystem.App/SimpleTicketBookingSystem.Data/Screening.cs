using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Data
{
    /// <summary>
    /// class for displaying available seats
    /// </summary>
    public class Screening
    {
        public Movie? Movie { get; set; }
        public DateTime Time { get; set; }

        /// <summary>
        /// method to display available seats
        /// </summary>
        public void DisplayAvailableSeats()
        {
            foreach (var seat in Movie.Seats.SeatsList)
            {
                if (seat.IsAvailable == true && seat is not VIPSeat)
                {
                    Console.WriteLine($" Row - {seat.Row}  Number - {seat.Number}  Price - {seat.Price}");
                }
                if (seat.IsAvailable == true && seat is VIPSeat)
                {
                    Console.WriteLine($" Row - {seat.Row}  Number - {seat.Number}  Price - {seat.Price} it is Vip seat");
                }
            }

        }

        public Screening(IMovie movie )
        {
            Movie = (Movie?)movie;
        }
    }
}
