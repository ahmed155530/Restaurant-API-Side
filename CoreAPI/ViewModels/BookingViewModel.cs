using CoreAPI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.ViewModels
{
    public class BookingViewModel
    {
        public DateTime? ReservedDate { get; set; }
        public int? CheckInTime { get; set; }
        public int? NOofGuests { get; set; }
        public string customer_Id { get; set; }
    }
}
