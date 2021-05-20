using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstDist
    {
        public int DistId { get; set; }
        public string DistName { get; set; }
        public string DistMobileNo { get; set; }
        public string DistAddress { get; set; }
        public string DistEmail { get; set; }
        public string DistProfilePicPath { get; set; }
        public string DistLogin { get; set; }
        public string DistPassword { get; set; }
        public string DistBackdoor { get; set; }
        public bool? DistMacCheck { get; set; }
        public bool? DistLocked { get; set; }
        public string DistFpsCode { get; set; }
        public string DistFpsLiscenceNo { get; set; }
        public string DistMrShopNo { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MobileNoToNotifyViaSms { get; set; }
        public string EmailToNotify { get; set; }
    }
}
