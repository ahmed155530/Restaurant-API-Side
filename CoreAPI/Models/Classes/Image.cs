using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int? food_Id { get; set; }
        [ForeignKey("food_Id")]
        public virtual Food food { get; set; }
        public byte[] ImageData { get; set; }
    }
}
