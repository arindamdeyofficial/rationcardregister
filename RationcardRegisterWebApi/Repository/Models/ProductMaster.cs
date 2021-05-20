using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductMaster
    {
        public int ProductMasterIdentity { get; set; }
        public int? DistId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string ProdDescription { get; set; }
        public string Uomtype { get; set; }
        public int? BaseUomId { get; set; }
        public int? ProductDeptMasterIdentity { get; set; }
        public int? ProductSubDeptMasterId { get; set; }
        public int? ProductClassMasterId { get; set; }
        public int? ProductSubClassMasterId { get; set; }
        public int? ProductMcMasterId { get; set; }
        public int? ProductBrandMasterId { get; set; }
        public int? ProductRateId { get; set; }
        public string ArticleCode { get; set; }
        public bool? IsDefaultProduct { get; set; }
        public bool? IsDefaultGiveRation { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
