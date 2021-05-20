using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstCustomer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public bool? HofFlag { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string RationCardId { get; set; }
        public int? HofId { get; set; }
        public int? DistId { get; set; }
        public string AdharNo { get; set; }
        public string RelationWithHof { get; set; }
        public string GaurdianName { get; set; }
        public string GaurdianRelation { get; set; }
        public string MobileNo { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
