using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductMcMaster
    {
        public int ProductMcMasterIdentity { get; set; }
        public string ProductMcCode { get; set; }
        public int? DistId { get; set; }
        public int? ProductDeptMasterId { get; set; }
        public int? ProductSubDeptMasterId { get; set; }
        public int? ProductClassMasterId { get; set; }
        public int? ProductSubClassMasterId { get; set; }
        public string ProductMcMasterDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
