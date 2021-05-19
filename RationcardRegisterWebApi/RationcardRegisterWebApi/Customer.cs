using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RationcardRegisterWebApi
{
    public class Customer: ICustomer
    {
        [JsonPropertyName("Customer_Id")]
        public int Customer_Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [JsonPropertyName("Adhar_No")]
        public string Adhar_No { get; set; }
        [JsonPropertyName("Relation_With_Hof")]
        public string Relation_With_Hof { get; set; }
        [JsonPropertyName("Mobile_No")]
        public string Mobile_No { get; set; }
    }
}
