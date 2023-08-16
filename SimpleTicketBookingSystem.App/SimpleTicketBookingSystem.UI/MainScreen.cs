using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Data.Screen;
using SimpleTicketBookingSystem.Enums;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.UI
{
    public class MainScreen : Screen
    {

        public SelectSeatsScreen _selectSeatsScreen;

        public MoviesScreen _moviesScreen;

        public IDataService _dataService;

        public MainScreen(SelectSeatsScreen selectSeatsScreen, MoviesScreen moviesScreen, IDataService dataService)
        {
            _selectSeatsScreen = selectSeatsScreen;
            _moviesScreen = moviesScreen;
            _dataService = dataService; 
        }

        public override void Show()
        {
            while (true)
            {

                

                var list = new List<ScreenLineEntry>
                {
                    new ScreenLineEntry { Text = "0. Exit" },
                    new ScreenLineEntry { Text = "1. Choose a movie" },
                    //new ScreenLineEntry { Text = "2. Select seats" },
                    //new ScreenLineEntry { Text = "3. Show your ticket" },
                };


                ScreenRender(list);



                SwitchHandler();

            }
        }

        public override void AdditionalSection()
        {
            //foreach (var movie in _dataService.Movies.MoviesList)
            //{
            //    //Console.WriteLine(movie.Seats.SeatsList[10].icon);
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
                MainScreenChoices choice = (MainScreenChoices)currentField;
                switch (choice)
                {
                    case MainScreenChoices.СhooseAMovie:
                        _moviesScreen.Show();
                        break;

                    case MainScreenChoices.addSiets:
                        _selectSeatsScreen.Show();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}