using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductSubDeptMaster
    {
        public int ProductSubDeptMasterIdentity { get; set; }
        public int? DistId { get; set; }
        public int? ProductDeptMasterId { get; set; }
        public string ProductSubDeptMasterDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
