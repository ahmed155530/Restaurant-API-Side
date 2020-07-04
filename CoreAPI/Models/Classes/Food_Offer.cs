using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Food_Offer
    {
        public int Id { get; set; }

        public int DiscountPercentage { get; set; }

        public int? offer_Id { get; set; }
        [ForeignKey("offer_Id")]
        public virtual Offer offer { get; set; }


        public int? food_Id { get; set; }
        [ForeignKey("food_Id")]
        public virtual Food food { get; set; }
    }
}
