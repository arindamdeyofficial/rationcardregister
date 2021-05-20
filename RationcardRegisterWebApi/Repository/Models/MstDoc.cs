using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstDoc
    {
        public int DocId { get; set; }
        public string DocFileName { get; set; }
        public string DocFilePath { get; set; }
        public int? DocTypeId { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstDocType DocType { get; set; }
    }
}
