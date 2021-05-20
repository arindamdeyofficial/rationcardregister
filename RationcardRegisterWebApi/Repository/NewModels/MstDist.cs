using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.NewModels
{
    public partial class MstDist
    {
        public int DistId { get; set; }
        public string DistName { get; set; }
        public bool? DistLocked { get; set; }
        public string MobileNoToNotifyViaSms { get; set; }
        public string EmailToNotify { get; set; }
        public string DistMobileNo { get; set; }
        public string DistEmail { get; set; }
        public string DistLogin { get; set; }
        public string DistAddress { get; set; }
        public string DistGoogleMapLocation { get; set; }
        public string DistFpsCode { get; set; }
        public string DistFpsLiscenceNo { get; set; }
        public string DistMrShopNo { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
