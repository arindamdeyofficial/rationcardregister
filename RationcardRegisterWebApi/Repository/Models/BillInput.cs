using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class BillInput
    {
        public int BillInputtIdentity { get; set; }
        public int? DistId { get; set; }
        public string BillXml { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
