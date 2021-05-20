using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstRel
    {
        public int MstRelWithHofId { get; set; }
        public string Relation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
