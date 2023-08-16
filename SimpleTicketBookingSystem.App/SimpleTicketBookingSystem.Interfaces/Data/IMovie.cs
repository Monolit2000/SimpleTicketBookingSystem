using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Interfaces.Data
{
    public interface IMovie
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string AgeRestriction { get; set; }
        public ISeats Seats { get; set; }

    }
}
