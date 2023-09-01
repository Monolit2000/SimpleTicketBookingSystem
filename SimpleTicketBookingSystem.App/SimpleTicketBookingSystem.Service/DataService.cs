using Newtonsoft.Json;
using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Service
{
    /// <summary>
    /// movie storage service
    /// </summary>
    public class DataService : IDataService
    {
        public IMovies Movies { get; set; }

        public List<IReservation> reservations { get; set; } = new List<IReservation>();  

        // public Reservation
        public DataService()
        {
            Movies = new Movies();
        }

        public void Reservation(IReservation reservation)
        {
            reservations.Add(reservation);
        }

        public bool Write(string jsonPath)
        {
            bool result = true;

            try
            {
                var jsonSettings = new JsonSerializerSettings();
                string jsonContent = JsonConvert.SerializeObject(reservations);
                string jsonContentFormatted = jsonContent;
                File.WriteAllText(jsonPath, jsonContentFormatted);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                result = false;
            }

            return result;
        }


    }
}
