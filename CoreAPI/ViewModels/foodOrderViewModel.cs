using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.ViewModels
{
    public class foodOrderViewModel
    {
        public string foodName { get; set; }
        public int? Quantity { get; set; }
        public float? OrderPrice { get; set; }
        public float? TotalOrderPrice { get; set; }
    }
}
