using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class CardCategory
    {
        [JsonPropertyName("CardCategoryId")]
        public int CardCategoryId { get; set; }
        [JsonPropertyName("CardCategoryDesc")]
        public string CardCategoryDesc { get; set; }
    }
}
