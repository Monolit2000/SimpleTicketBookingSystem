using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Interfaces.Data
{
    public interface IReservation
    {
        public ISeat? Seat { get; set; }
        public string CustomerName { get; set; }

    }
}
