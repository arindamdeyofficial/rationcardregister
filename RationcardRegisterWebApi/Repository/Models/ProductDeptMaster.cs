using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductDeptMaster
    {
        public int ProductDeptMasterIdentity { get; set; }
        public int? DistId { get; set; }
        public string ProductDeptDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
