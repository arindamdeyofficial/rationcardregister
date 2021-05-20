using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.NewModels
{
    public partial class MstCustomer
    {
        public int CustomerRowId { get; set; }
        public int? CustomerSerial { get; set; }
        public string Name { get; set; }
        public bool? IsHof { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int? FamilyId { get; set; }
        public int? HofId { get; set; }
        public string AdharNo { get; set; }
        public int? RelationWithHofId { get; set; }
        public string GaurdianName { get; set; }
        public int? GaurdianRelId { get; set; }
        public string MobileNo { get; set; }
        public string CardNumber { get; set; }
        public int? CardCategoryId { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
