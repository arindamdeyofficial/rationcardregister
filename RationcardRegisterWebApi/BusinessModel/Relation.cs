using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Relation
    {
        [JsonPropertyName("RelationId")]
        public int RelationId { get; set; }
        [JsonPropertyName("RelationDesc")]
        public string RelationDesc { get; set; }
    }
}
