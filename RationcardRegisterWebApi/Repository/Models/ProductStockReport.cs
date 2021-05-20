using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductStockReport
    {
        public int ProductStockReportIdentity { get; set; }
        public int? DistId { get; set; }
        public int? ProdId { get; set; }
        public int? CatId { get; set; }
        public int? UomId { get; set; }
        public decimal? OpenningBalance { get; set; }
        public decimal? StockRecieved { get; set; }
        public decimal? TotalStock { get; set; }
        public decimal? StockSold { get; set; }
        public decimal? HandlingLoss { get; set; }
        public decimal? ClosingBalance { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
