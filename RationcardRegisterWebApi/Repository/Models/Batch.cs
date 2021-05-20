using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Batch
    {
        public string BatchId { get; set; }
        public short? BatchStudentNumber { get; set; }
        public string BatchTeacherId { get; set; }
    }
}
