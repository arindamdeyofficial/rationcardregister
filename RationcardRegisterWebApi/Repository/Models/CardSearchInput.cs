using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class CardSearchInput
    {
        public int CardSearchInputIdentity { get; set; }
        public int? DistId { get; set; }
        public string SearchBy { get; set; }
        public string SearchText { get; set; }
        public string CatId { get; set; }
        public string DtFrom { get; set; }
        public string Dto { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
