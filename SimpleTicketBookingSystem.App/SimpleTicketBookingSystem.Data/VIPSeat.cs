using SimpleTicketBookingSystem.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicketBookingSystem.Data
{
    public class VIPSeat :  ISeat
    {
        public string icon { get; set; } = "H";
        public int Row { get; set; }
        public int PriceMultiplier { get; set; }

        private int _price;
        public int Price 
        { 
            get
            {
                return _price;
            }
            set
            {
                _price = PriceMultiplier * value;
            }
        }
       
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public string ForegroundColor { get; set; }

        //public VIPSeat()
        //{
        //    Price = PriceMultiplier * Price;
        //}
        
    }
}
