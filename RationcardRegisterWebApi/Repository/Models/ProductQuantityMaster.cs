using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductQuantityMaster
    {
        public int ProductQuantityMasterIdentity { get; set; }
        public int? ProdId { get; set; }
        public int? CatId { get; set; }
        public decimal? DefaultQuantityInBaseUom { get; set; }
        public bool? IsQuantityForFamily { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
