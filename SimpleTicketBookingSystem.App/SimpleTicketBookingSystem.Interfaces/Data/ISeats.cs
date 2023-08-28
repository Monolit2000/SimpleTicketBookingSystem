using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Interfaces.Data
{
    /// <summary>
    /// seat list storage interface
    /// </summary>
    public interface ISeats
    {
        List<ISeat> SeatsList { get; set; }
    }
}
