using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class MstDocType
    {
        public MstDocType()
        {
            MstDocs = new HashSet<MstDoc>();
        }

        public int DocTypeId { get; set; }
        public string DocTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<MstDoc> MstDocs { get; set; }
    }
}
