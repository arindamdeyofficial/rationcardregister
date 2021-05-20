using BusinessModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
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
    public class AdminController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly RationCardContext _oldContext;
        private readonly RationcardRegisterContext _newContext;
        private readonly IUnitOfWork _unitOfWork;
        private IDbRepository<Repository.NewModels.MstCustomer> _repository { get; set; }

        public AdminController(ILogger<CustomerController> logger
            , RationCardContext oldContext, RationcardRegisterContext newContext
            , IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _oldContext = oldContext;
            _newContext = newContext;
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Repository.NewModels.MstCustomer>();
        }

        [HttpGet]
        [Route("CopyCustomersFromOldDb")]
        public async Task<bool> CopyCustomersFromOldDb()
        {
            bool isSuccess = false;
            var customers = new List<Repository.NewModels.MstCustomer>();
            var dataClass = new OldDataMgmt(_oldContext, _newContext);
            customers = dataClass.FetchDataRaw();
            try
            {
                _repository.InsertRange(customers);
                var result = await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            }
            catch(Exception ex)
            {

            }
            
            return isSuccess;
        }
    }
}
