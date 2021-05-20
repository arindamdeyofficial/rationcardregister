using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Logger
    {
        public int LoggerIdentity { get; set; }
        public int? DistId { get; set; }
        public string LogText { get; set; }
        public string MacId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
