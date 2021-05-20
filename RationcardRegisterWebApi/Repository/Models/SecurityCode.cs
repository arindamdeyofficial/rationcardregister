using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class SecurityCode
    {
        public int SecurityCodeIdentity { get; set; }
        public string SecurityCodeInMail { get; set; }
        public string MailId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
