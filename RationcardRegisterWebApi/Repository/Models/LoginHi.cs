using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class LoginHi
    {
        public int LoginHisId { get; set; }
        public string DistLogin { get; set; }
        public DateTime? LoginTime { get; set; }
        public bool? LoginSuccess { get; set; }
        public string MacId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
