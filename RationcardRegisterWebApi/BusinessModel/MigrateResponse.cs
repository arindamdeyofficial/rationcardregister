using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class MigrateResponse
    {
        [JsonPropertyName("MigrationStatus")]
        public bool MigrationStatus { get; set; }
        [JsonPropertyName("CustomerCountOldDb")]
        public int CustomerCountOldDb { get; set; }
        [JsonPropertyName("CustomerCountNewDb")]
        public int CustomerCountNewDb { get; set; }
    }
}
