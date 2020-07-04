using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models.Classes
{
    public class Customer 
    {
        [ForeignKey("User")]
        [Key]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        //public int Id { get; set; }
        public string Name { get; set; }
       //public double PhoneNumber { get; set; }
       

        public virtual ICollection<Booking> bookings { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
    }
}
