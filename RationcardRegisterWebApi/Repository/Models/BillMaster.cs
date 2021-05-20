using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class BillMaster
    {
        public int BillIdIdentity { get; set; }
        public int? DistId { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? BillAmountRoundedOff { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public string BillSerialNumber { get; set; }
        public string BillNumber { get; set; }
        public int? Fortnight { get; set; }
        public int? TotalCardServed { get; set; }
        public string RationcardNumbers { get; set; }
        public string PrdDefaultQuantitySummary { get; set; }
        public bool? IsCalculated { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
