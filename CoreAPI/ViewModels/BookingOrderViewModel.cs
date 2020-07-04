using CoreAPI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.ViewModels
{
    public class BookingOrderViewModel
    {
        public virtual Booking booking { get; set; }
        public virtual ICollection<Food_Order> food_Orders { get; set; }
    }
}
