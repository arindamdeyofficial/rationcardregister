using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductUom
    {
        public int ProductUomIdentity { get; set; }
        public int? DistId { get; set; }
        public int? ProductId { get; set; }
        public int? UomId { get; set; }
        public bool? IsBaseuom { get; set; }
        public decimal? ConversionFactorWithBaseUom { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
