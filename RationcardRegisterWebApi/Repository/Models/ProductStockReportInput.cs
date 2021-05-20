using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductStockReportInput
    {
        public int ProductStockReportInputIdentity { get; set; }
        public int? DistId { get; set; }
        public string DtFrom { get; set; }
        public string DtTo { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
