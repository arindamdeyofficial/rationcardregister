using BusinessModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Models;
using Repository.NewModels;
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
        private readonly RationCardContext _oldContext;
        private readonly RationcardRegisterContext _newContext;

        public CustomerController(ILogger<CustomerController> logger
            , RationCardContext oldContext, RationcardRegisterContext newContext)
        {
            _logger = logger;
            _oldContext = oldContext;
            _newContext = newContext;
        }

        [HttpGet]
        [Route("FetchAllCustomers")]
        public List<Customer> FetchAllCustomers()
        {
            var customers = new List<Customer>();
            var dataClass = new OldDataMgmt(_oldContext, _newContext);
            customers = dataClass.FetchCustomersNew();
            return customers;
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public bool DeleteCustomer(Customer cust)
        {
            bool isSuccess = false;

            return isSuccess;
        }
    }
}
