using AutoMapper;
using BusinessModel;
using Microsoft.AspNetCore.Cors;
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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly RationCardContext _oldContext;
        private readonly RationcardRegisterContext _newContext;
        private readonly IUnitOfWork _unitOfWork;
        private IDbRepository<Repository.NewModels.MstCustomer> _repository { get; set; }
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger
            , RationCardContext oldContext, RationcardRegisterContext newContext
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _logger = logger;
            _oldContext = oldContext;
            _newContext = newContext;
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Repository.NewModels.MstCustomer>();
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetMasterData")]
        public async Task<MasterData> GetMasterData()
        {
            var masterData = new MasterData();
            try
            {
                masterData.Customers = FetchAllCustomers()?.Result;
                masterData.Hofs = masterData.Customers.Where(c => c.IsHof ?? false).Select(c =>
                    new Hof
                    {
                        HofId = c.HofId??0,
                        HofActiveCard = masterData.Customers
                                        .Where(cu => cu.HofId.Equals(c.CustomerRowId) 
                                                && (cu.Active??false)).Count(),
                        HofCardNumber = c.CardNumber,
                        HofMobileNumber = c.CardNumber,
                        HofName = c.Name
                    }).ToList();
                masterData.CardCategories = _newContext.MstCats.Select(cat =>
                    new CardCategory
                    {
                        CardCategoryId = cat.CatId,
                        CardCategoryDesc = cat.CatDesc
                    }).ToList();
                masterData.Relations = _newContext.MstRels.Select(rel =>
                    new Relation
                    {
                        RelationId = rel.MstRelId,
                        RelationDesc = rel.Relation
                    }).ToList();
            }
            catch (Exception ex)
            {

            }
            return masterData;
        }

        [HttpGet]
        [Route("FetchAllCustomers")]
        public async Task<List<Customer>> FetchAllCustomers()
        {
            var customers = new List<Customer>();
            try
            {
                var dataClass = new OldDataMgmt(_oldContext, _newContext, _unitOfWork, _mapper);
                customers = await dataClass.FetchCustomersNew();
            }
            catch (Exception ex)
            {

            }
            return customers.GetRange(0, 10);
        }
       
        [HttpPost]
        [Route("DeleteCustomer")]
        public async Task<bool> DeleteCustomer(Customer cust)
        {
            bool isSuccess = true;
            try
            {
                _newContext.MstCustomers.Remove(_mapper.Map<Customer, Repository.NewModels.MstCustomer>(cust));
                var result = await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        [HttpPost]
        [Route("AddOrEditCustomer")]
        public async Task<bool> AddOrEditCustomer(Customer cust)
        {
            bool isSuccess = true;
            try
            {
                if (_newContext.MstCustomers.Any(a => a.Equals(cust)))
                {
                    _newContext.MstCustomers.Update(_mapper.Map<Customer, Repository.NewModels.MstCustomer>(cust));
                }
                else
                {
                    _newContext.MstCustomers.Add(_mapper.Map<Customer, Repository.NewModels.MstCustomer>(cust));
                }
                var result = await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
