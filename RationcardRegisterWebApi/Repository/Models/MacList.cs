using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MacList
    {
        public int MacIdIdentity { get; set; }
        public int? DistId { get; set; }
        public string MacId { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
