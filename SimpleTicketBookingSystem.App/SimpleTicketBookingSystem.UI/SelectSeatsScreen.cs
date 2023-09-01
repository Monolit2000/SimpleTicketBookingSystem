using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Data.Screen;
using SimpleTicketBookingSystem.Enums;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.UI
{
    /// <summary>
    /// seat selection screen
    /// </summary>
    public class SelectSeatsScreen : Screen
    {
        public IDataService _dataService;

        public SelectSeatsScreen( IDataService dataService )
        {
            _dataService = dataService;
        }

        public IMovie _movie { get; set; }

        public override void Show(IMovie movie)
        {

            _movie = movie;

            while (true)
            {
                var list = new List<ScreenLineEntry>();
  

                Screening screen = new Screening(movie);

                screen.DisplayAvailableSeats();          

                Console.WriteLine("choose row of seats: ");
                var rowOfSeats = int.Parse(Console.ReadLine());

                Console.WriteLine("choose number of seats: ");
                var numberOfSeats = int.Parse(Console.ReadLine());

                Console.WriteLine("write your name: ");
                var customerName = Console.ReadLine();

                ISeat seat = _movie.Seats.SeatsList.FirstOrDefault(s => s.Row == rowOfSeats && s.Number == numberOfSeats);

                //seat reservation
                var resrvatuion = new Reservation(movie, seat, customerName);

                _dataService.Reservation(resrvatuion);

                return;

            }
        }
    }
}
