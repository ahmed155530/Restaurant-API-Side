using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Food_Order
    {
        
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public float? OrderPrice { get; set; }
        public float? TotalOrderPrice { get; set; }
        public int? food_Id { get; set; }
        [ForeignKey("food_Id")]
        public virtual Food food { get; set; }

        public string foodName { get; set; }

        public int? order_Id { get; set; }
        [ForeignKey("order_Id")]
        public virtual Order order { get; set; }

        public int booking_Id { get; set; }
        [ForeignKey("booking_Id")]
        public virtual Booking booking { get; set; }



    }
}
