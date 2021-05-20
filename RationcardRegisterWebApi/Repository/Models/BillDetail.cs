using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class BillDetail
    {
        public int BillDetailsIdIdentity { get; set; }
        public int? BillId { get; set; }
        public int? ProdId { get; set; }
        public int? CatId { get; set; }
        public decimal? Quantity { get; set; }
        public int? QuantityUomId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string ProdDescription { get; set; }
        public string Uomtype { get; set; }
        public int? BaseUomId { get; set; }
        public string ProductDept { get; set; }
        public string ProductSubDept { get; set; }
        public string ProductClass { get; set; }
        public string ProductSubClass { get; set; }
        public string ProductMc { get; set; }
        public string ProductBrand { get; set; }
        public decimal? ProductStock { get; set; }
        public decimal? ProductSellingRate { get; set; }
        public decimal? ProductBuyingRate { get; set; }
        public decimal? ProductMrpRate { get; set; }
        public string ArticleCode { get; set; }
        public bool? IsDefaultProduct { get; set; }
        public bool? IsDefaultGiveRation { get; set; }
        public bool? IsCalculated { get; set; }
    }
}
