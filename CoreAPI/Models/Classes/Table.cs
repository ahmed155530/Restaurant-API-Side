using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Table
    {
        public int Id { get; set; }
        public int NO { get; set; }
        public int NOofPersons { get; set; }
        //public bool IsAvailable { get; set; }
        public virtual ICollection<Booking> bookings { get; set; }
    }
}
