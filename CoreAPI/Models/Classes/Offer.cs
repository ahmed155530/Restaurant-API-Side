using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }

        public virtual ICollection<Food_Offer> food_Offers { get; set; }
    }
}
