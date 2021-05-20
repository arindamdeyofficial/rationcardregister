using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TxnRationCard
    {
        public int RationCardId { get; set; }
        public string Number { get; set; }
        public int? CardCategoryId { get; set; }
        public int? CustomerId { get; set; }
        public int? DistId { get; set; }
        public string Remarks { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
