using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductClassMaster
    {
        public int ProductClassMasterIdentity { get; set; }
        public int? DistId { get; set; }
        public int? ProductDeptMasterId { get; set; }
        public int? ProductSubDeptMasterId { get; set; }
        public string ProductClassMasterDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
