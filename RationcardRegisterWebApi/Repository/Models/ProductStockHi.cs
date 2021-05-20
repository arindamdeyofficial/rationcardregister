using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductStockHi
    {
        public int ProductStockHisIdentity { get; set; }
        public string UserId { get; set; }
        public int? ProdId { get; set; }
        public int? UomId { get; set; }
        public decimal? ProdQuantity { get; set; }
        public decimal? AllowedDamageQuantityPerUnit { get; set; }
        public decimal? TotalAllowedDamageQuantity { get; set; }
        public decimal? TotalDamageQuantityInReal { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
