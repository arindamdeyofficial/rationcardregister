using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class AppStartHi
    {
        public int AppStartHisId { get; set; }
        public string MacId { get; set; }
        public string InternalIp { get; set; }
        public string PublicIp { get; set; }
        public string GatewayAddr { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
