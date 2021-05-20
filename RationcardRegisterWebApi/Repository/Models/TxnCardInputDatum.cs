using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TxnCardInputDatum
    {
        public int Id { get; set; }
        public int? DistId { get; set; }
        public string MacId { get; set; }
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string HofFlag { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string RationCardId { get; set; }
        public string HofId { get; set; }
        public string HofName { get; set; }
        public string AdharNo { get; set; }
        public string RelationWithHofId { get; set; }
        public string RelationWithHofDesc { get; set; }
        public string GaurdianName { get; set; }
        public string GaurdianRelationId { get; set; }
        public string GaurdianRelationDesc { get; set; }
        public string MobileNo { get; set; }
        public string Number { get; set; }
        public string CardCategoryId { get; set; }
        public string CardCategoryDesc { get; set; }
        public string Remarks { get; set; }
        public string Active { get; set; }
        public string ActiveInactivatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
