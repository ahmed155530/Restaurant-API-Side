using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReservationDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReservedDate { get; set; }
        public int? CheckInTime { get; set; }
        public int? CheckOutTime { get; set; }

        public float TotalPrice { get; set; }
        public string customer_Id { get; set; }
        [ForeignKey("customer_Id")]
        public virtual Customer customer { get; set; }


        public int? table_Id { get; set; }
        [ForeignKey("table_Id")]
        public virtual Table table { get; set; }


        //public int? order_Id { get; set; }
        //[ForeignKey("order_Id")]
        //public virtual Order order { get; set; }

        public virtual ICollection<Food_Order> food_Orders { get; set; }

    }
}
