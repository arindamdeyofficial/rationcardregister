using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RationcardRegisterWebApi
{
    public interface ICustomer
    {
        public int Customer_Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Adhar_No { get; set; }
        public string Relation_With_Hof { get; set; }
        public string Mobile_No { get; set; }
    }
}
