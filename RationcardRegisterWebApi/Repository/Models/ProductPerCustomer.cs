using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class ProductPerCustomer
    {
        public int ProductPerCustomerIdentity { get; set; }
        public string UserId { get; set; }
        public int? MstCustId { get; set; }
        public int? ProdId { get; set; }
        public int? UomId { get; set; }
        public decimal? ProdQuantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
