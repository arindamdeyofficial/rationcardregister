using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RationcardRegisterWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Customer> FetchAllCustomers()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer
            {
                Customer_Id = 1,
                Name = "MINATI GHOSE",
                Adhar_No = "56464564",
                Age = 57,
                Mobile_No = "7278481425",
                Relation_With_Hof = "Self",
                Address = "PRAGATI PALLI, RAJPUR SONARPUR,24(s)-700147"
            });
            customers.Add(new Customer
            {
                Customer_Id = 2,
                Name = "ABHIJT GHOSE",
                Adhar_No = "333956000000",
                Age = 24,
                Mobile_No = "7278481425",
                Relation_With_Hof = "Self",
                Address = "PRAGATI PALLI, RAJPUR SONARPUR,24(s)-700147"
            });
            customers.Add(new Customer
            {
                Customer_Id = 3,
                Name = "RAMENDRA BHHATTACHRYA",
                Adhar_No = "268838000000",
                Age = 70,
                Mobile_No = "8582852728",
                Relation_With_Hof = "Self",
                Address = "MN BASU ROAD, WARD NO-2, SONARPUR,S24 PGS"
            });
            customers.Add(new Customer
            {
                Customer_Id = 4,
                Name = "KAISAR ALAM",
                Adhar_No = "425522000000",
                Age = 28,
                Mobile_No = "7044188543",
                Relation_With_Hof = "Self",
                Address = "GANIMA ROAD, NEAR SALEHA MASJID MALLICKPUR HABIB CHAWK, MALLIKPORE RSM WARD NO-21"
            });

            return customers;
        }
    }
}
