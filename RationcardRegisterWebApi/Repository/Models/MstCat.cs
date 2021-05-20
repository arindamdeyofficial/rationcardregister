using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstCat
    {
        public int CatId { get; set; }
        public string CatKey { get; set; }
        public string CatDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
