using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductSubClassMaster
    {
        public int ProductSubClassMasterIdentity { get; set; }
        public int? DistId { get; set; }
        public int? ProductDeptMasterId { get; set; }
        public int? ProductSubDeptMasterId { get; set; }
        public int? ProductClassMasterId { get; set; }
        public string ProductSubClassMasterDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
