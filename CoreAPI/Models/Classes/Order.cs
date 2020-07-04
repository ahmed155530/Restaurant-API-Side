using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Order
    {
        //[ForeignKey("booking")]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        //public float TotalPrice { get; set; }

        //public int? food_Id { get; set; }
        //[ForeignKey("food_Id")]
        //public virtual Food food { get; set; }

        //public int? booking_Id { get; set; }
        //[ForeignKey("booking_Id")]
        //public virtual Booking booking { get; set; }

        public virtual ICollection<Food_Order> food_Orders { get; set; }
    }
}
