using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class EnumType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int EnumId { get; set; }
        public DateTime LastModified { get; set; }
    }
}
