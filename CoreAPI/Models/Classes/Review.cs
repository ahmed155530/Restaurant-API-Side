using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewContent { get; set; }
        public DateTime PostingDate { get; set; }
        public int? food_Id { get; set; }
        [ForeignKey("food_Id")]
        public virtual Food food { get; set; }

        public string customer_Id { get; set; }
        [ForeignKey("customer_Id")]
        public virtual Customer customer { get; set; }
    }
}
