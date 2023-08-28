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
    /// <summary>
    /// movie selection screen
    /// </summary>
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
        }

        public override void EnterScreen()
        {
            try
            {
                _selectSeatsScreen.Show(_dataService.Movies.MoviesList[currentField]);

            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }


    }
}
