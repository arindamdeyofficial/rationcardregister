using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.NewModels
{
    public partial class AppStartHi
    {
        public string InternalIp { get; set; }
        public string PublicIp { get; set; }
        public string GatewayAddr { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
