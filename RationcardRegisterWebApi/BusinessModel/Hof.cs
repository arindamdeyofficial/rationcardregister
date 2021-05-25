using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Hof
    {
        [JsonPropertyName("HofId")]
        public int HofId { get; set; }
        [JsonPropertyName("HofName")]
        public string HofName { get; set; }
        [JsonPropertyName("HofMobileNumber")]
        public string HofMobileNumber { get; set; }
        [JsonPropertyName("HofCardNumber")]
        public string HofCardNumber { get; set; }
        [JsonPropertyName("HofActiveCard")]
        public int HofActiveCard { get; set; }
        [JsonPropertyName("FamilyId")]
        public int FamilyId { get; set; }
    }
}
