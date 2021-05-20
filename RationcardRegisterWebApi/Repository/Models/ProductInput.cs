using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductInput
    {
        public int ProductInputIdentity { get; set; }
        public int? DistId { get; set; }
        public string ProductXml { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
