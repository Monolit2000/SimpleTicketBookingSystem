using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Data
{
    /// <summary>
    /// interface implementation
    /// </summary>
    public class Seats : ISeats
    {
       public List<ISeat> SeatsList { get; set; }


        public Seats()
        {
            SeatsList = SeatsListAdd(5, 5);
        }

        /// <summary>
        /// seats list filling method
        /// </summary>
        /// <param name="RowCount"></param>
        /// <param name="ColomCount"></param>
        /// <returns></returns>
        private List<ISeat> SeatsListAdd(int RowCount, int ColomCount)
        {
            List<ISeat> Seats = new List<ISeat>();

            for (int Row = 1; Row <= RowCount; Row++)
            {
                for (int Colom = 1; Colom <= ColomCount; Colom++)
                {
                    //if the row is the last, then fill it with VIP seats
                    if (Row == RowCount)
                    {
                        Seats.Add(new VIPSeat { Row = Row, Number = Colom, PriceMultiplier = 2, Price = 100, IsAvailable = true, icon = "H" });
                    }

                    else
                    {
                        Seats.Add(new Seat { Row = Row, Number = Colom, Price = 100, IsAvailable = true, icon = "h" });
                    }
                }
            }

            return Seats;
        }



    }
}
