using SimpleTicketBookingSystem.Data.Screen;
using SimpleTicketBookingSystem.Enums;
using SimpleTicketBookingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.UI
{
    public class MoviesScreen : Screen
    {
        public IDataService _dataService;
        public SelectSeatsScreen _selectSeatsScreen;

        #region ctor
        public MoviesScreen(IDataService dataService, SelectSeatsScreen selectSeatsScreen)
        {
            _dataService = dataService;
            _selectSeatsScreen = selectSeatsScreen;
        }
        #endregion

        public override void Show()
        {
            while (true)
            {


                var list = new List<ScreenLineEntry>();
                //{
                //    new ScreenLineEntry { Text = "0. Exit" },
                //    new ScreenLineEntry { Text = "1. Select movies" },
                //    new ScreenLineEntry { Text = "2. Create a new settings" },
                //};


                foreach (var movie in _dataService.Movies.MoviesList)
                {
                    list.Add(new ScreenLineEntry { Text = movie.Title });
                }

                ScreenRender(list);

                SwitchHandler();

            }
        }

        public override void AdditionalSection()
        {

            Console.WriteLine(currentField);

            //foreach (var movie in _dataService.Movies.MoviesList)
            //{
             
            //    foreach (var seat in movie.Seats.SeatsList)
            //    {
            //        Console.WriteLine(seat.icon);
            //    }
            //}
        }

        public override void EnterScreen()
        {
            try
            {
                //MovieScreenChoices choice = (MovieScreenChoices)currentField;
                //switch (currentField)
                //{
                //    case MovieScreenChoices.addSiets:
                //        _selectSeatsScreen.Show(_dataService.Movies.MoviesList[choice]);
                //        break;
                //}

                _selectSeatsScreen.Show(_dataService.Movies.MoviesList[currentField]);

            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }


    }
}
