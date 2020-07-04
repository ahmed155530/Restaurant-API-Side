using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.ViewModels
{
    public class ReviewFoodViewModel
    {
        public int id { get; set; }
        public int food_Id { get; set; }
        public string foodName { get; set; }
        public string reviewContent { get; set; }
        public DateTime postingDate { get; set; }
    }
}
