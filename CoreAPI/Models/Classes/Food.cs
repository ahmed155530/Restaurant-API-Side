using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public int? foodCategory_Id { get; set; }
        [ForeignKey("foodCategory_Id")]
        public virtual FoodCategory foodCategory { get; set; }

        public virtual ICollection<Image> images { get; set; }

        public virtual ICollection<Food_Offer> food_Offers { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
    }
}
