using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public DateTime LastModified { get; set; }
    }
}
