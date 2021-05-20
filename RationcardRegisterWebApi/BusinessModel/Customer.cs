using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Customer: ICustomer
    {
        [JsonPropertyName("SerialNumber")]
        public int SerialNumber { get; set; }
        [JsonPropertyName("CustomerId")]
        public int CustomerId { get; set; }
        [JsonPropertyName("FamilyId")]
        public int FamilyId { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [JsonPropertyName("AdharNo")]
        public string AdharNo { get; set; }
        [JsonPropertyName("RelationWithHof")]
        public string RelationWithHof { get; set; }
        [JsonPropertyName("MobileNo")]
        public string MobileNo { get; set; }
        [JsonPropertyName("RationcardNumber")]
        public string RationcardNumber { get; set; }
        [JsonPropertyName("Ishof")]
        public bool? Ishof { get; set; }
        [JsonPropertyName("HofId")]
        public int? HofId { get; set; }
        [JsonPropertyName("GaurdianName")]
        public string GaurdianName { get; set; }
        [JsonPropertyName("GaurdianRelation")]
        public string GaurdianRelation { get; set; }
        [JsonPropertyName("Active")]
        public bool? Active { get; set; }
        [JsonPropertyName("CardCategory")]
        public string CardCategory { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonPropertyName("InactivatedDate")]
        public DateTime? InactivatedDate { get; set; }
    }
}
