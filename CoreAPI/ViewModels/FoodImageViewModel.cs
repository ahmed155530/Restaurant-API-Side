using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.ViewModels
{
    public class FoodImageViewModel
    {
        public IFormFile image { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
       public int? foodCategory_Id { get; set; }

    }
}
