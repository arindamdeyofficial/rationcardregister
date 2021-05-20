using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstRole
    {
        public int RoleId { get; set; }
        public int? DistId { get; set; }
        public string RoleDesc { get; set; }
        public string ControlIdToHide { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
