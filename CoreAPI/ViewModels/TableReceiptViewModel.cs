using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.ViewModels
{
    public class TableReceiptViewModel
    {
        public string customerName { get; set; }
        public string ReservedDate { get; set; }
        public int? CheckInTime { get; set; }
        public int? CheckOutTime { get; set; }
        public int? tableNO { get; set; }
        public int? NOofPersons { get; set; }
    }
}
