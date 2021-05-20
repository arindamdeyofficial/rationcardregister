using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class MasterData
    {
        [JsonPropertyName("Customers")]
        public List<Customer> Customers { get; set; }
        [JsonPropertyName("Hofs")]
        public List<Hof> Hofs { get; set; }
        [JsonPropertyName("Relations")]
        public List<Relation> Relations { get; set; }
        [JsonPropertyName("CardCategories")]
        public List<CardCategory> CardCategories { get; set; }
    }
}
