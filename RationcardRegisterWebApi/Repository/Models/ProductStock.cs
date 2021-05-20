using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductStock
    {
        public int ProductStockIdentity { get; set; }
        public int? DistId { get; set; }
        public int? ProdId { get; set; }
        public int? CatId { get; set; }
        public int? UomId { get; set; }
        public decimal? ProdQuantity { get; set; }
        public decimal? AllowedDamageQuantityPerUnit { get; set; }
        public decimal? TotalAllowedDamageQuantity { get; set; }
        public decimal? TotalDamageQuantityInReal { get; set; }
        public bool? IsStockIn { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
