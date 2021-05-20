using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class BillCounter
    {
        public int BillCounterIdentity { get; set; }
        public int? DistId { get; set; }
        public int? TotalBillCounter { get; set; }
        public int? DayBillCounterOrCount { get; set; }
        public DateTime? BillDate { get; set; }
    }
}
