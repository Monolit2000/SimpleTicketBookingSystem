using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Interfaces.Data
{
    /// <summary>
    /// Interface for storing movie list
    /// </summary>
    public interface IMovies
    {
      public List<IMovie> MoviesList { get; set; }
    }
}
