using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductRate
    {
        public int ProductRateIdentity { get; set; }
        public int? ProdId { get; set; }
        public decimal? BuyingRateInBaseUom { get; set; }
        public decimal? SellingRateInBaseUom { get; set; }
        public decimal? MrpRateInBaseUom { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
