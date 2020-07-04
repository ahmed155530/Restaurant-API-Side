using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Food> foods { get; set; }
    }
}
