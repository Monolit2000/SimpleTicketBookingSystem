using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Data.Screen;
using SimpleTicketBookingSystem.Enums;
using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.UI
{
    public class SelectSeatsScreen : Screen 
    {
        
        public IMovie _movie { get; set; }

        public List<ScreenLineEntry> list = new List<ScreenLineEntry>();

        //public override void AdditionalSection()
        // {

        //    // Console.WriteLine();

        // }

        public override void Show(IMovie movie)
        {

            _movie = movie;

            while (true)
            {
                var list = new List<ScreenLineEntry>();
                //{
                // new ScreenLineEntry { Text = "0. Exit" },
                // new ScreenLineEntry { Text = "1. Enter" },
                // new ScreenLineEntry { Text = "2. Create a new settings" },
                //};

                Screening screen = new Screening(movie);

                screen.DisplayAvailableSeats();
              
                //try
                //{
                //    int rowOfSeats = int.Parse(Console.ReadLine());
                //}
                //catch (FormatException)
                //{
                //    Console.WriteLine("Invalid input. Please enter a valid integer.");
                //}



                Console.WriteLine("choose row of seats: ");
                var rowOfSeats = int.Parse(Console.ReadLine());


                Console.WriteLine("choose number of seats: ");
                var numberOfSeats = int.Parse(Console.ReadLine());

                Console.WriteLine("write your name: ");
                var customerName = Console.ReadLine();

                ISeat seat = _movie.Seats.SeatsList.FirstOrDefault(s => s.Row == rowOfSeats && s.Number == numberOfSeats);


                // ScreenRender(list);

                // SwitchHandler();


                var resrvatuion = new Reservation(movie, seat, customerName);

                //Console.Clear();
                //Console.WriteLine(seat.IsAvailable);
                //Console.ReadLine();
                return;

            }
        }

        public override void EnterScreen()
        {
            try
            {


                //var resrvatuion = new Reservation(_movie, _movie.Seats.SeatsList[currentField]);
                //list.Clear();
                //switch (currentField)
                //{

                //}


                //SelectSeatsScreenChoices choice = (SelectSeatsScreenChoices)currentField;
                //switch (choice)
                //{
                //    case SelectSeatsScreenChoices.Exit:
                //        break;

                //    case SelectSeatsScreenChoices.Enter:
                //        break;

                //   case SelectSeatsScreenChoices.Exit:
                //     break;

                //}
            }
             
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }


    }
}
