using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class CategoryWise
    {
        [JsonPropertyName("CategoryDetails")]
        public CardCategory CategoryDetails { get; set; }
        [JsonPropertyName("CardCountActive")]
        public int CardCountActive { get; set; }
        [JsonPropertyName("CardCountTotal")]
        public int CardCountTotal { get; set; }
    }
}
