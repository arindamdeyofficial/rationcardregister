using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.NewModels
{
    public partial class LoginHi
    {
        public int? DistId { get; set; }
        public string DistLogin { get; set; }
        public bool? LoginSuccess { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
