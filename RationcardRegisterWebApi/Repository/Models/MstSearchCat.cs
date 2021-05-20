using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstSearchCat
    {
        public int SearchCatId { get; set; }
        public string SearchCatKey { get; set; }
        public string SearchCatDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
