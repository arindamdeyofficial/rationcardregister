using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class AppConfig
    {
        public int AppConfigIdentity { get; set; }
        public int? DistId { get; set; }
        public string KeyText { get; set; }
        public string ValueText { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
