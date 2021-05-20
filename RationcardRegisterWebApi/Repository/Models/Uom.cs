using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Uom
    {
        public int UomIdIdentity { get; set; }
        public int? DistId { get; set; }
        public string Uomname { get; set; }
        public string Uomtype { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
