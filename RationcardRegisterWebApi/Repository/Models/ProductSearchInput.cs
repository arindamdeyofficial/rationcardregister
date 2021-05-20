using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductSearchInput
    {
        public int ProductSearchInputIdentity { get; set; }
        public int? DistId { get; set; }
        public string BarCode { get; set; }
        public string ArticleCode { get; set; }
        public string PrdName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefaultToGiveRation { get; set; }
        public bool? IsDefaultPrd { get; set; }
        public string Dept { get; set; }
        public string SubDept { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public string Mc { get; set; }
        public string McCode { get; set; }
        public string Brand { get; set; }
        public string BrandCompany { get; set; }
        public DateTime? DtFrom { get; set; }
        public DateTime? DtTo { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
