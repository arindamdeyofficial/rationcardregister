using AutoMapper;
using BusinessModel;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Models;
using Repository.NewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        private readonly IMapper _mapper;

        public AdminController(ILogger<CustomerController> logger
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
        [Route("CopyCustomersFromOldDb")]
        public async Task<MigrateResponse> CopyCustomersFromOldDb()
        {
            bool isSuccess = true;
            var customers = new List<Customer>();
            var dataClass = new OldDataMgmt(_oldContext, _newContext, _unitOfWork, _mapper);
            customers = await dataClass.FetchDataOld();
            try
            {
                if (_newContext.MstCustomers.Count() == 0)
                {
                    _repository.InsertRange(_mapper.Map<List<Customer>, List<Repository.NewModels.MstCustomer>>(customers));
                    var result = await _unitOfWork.CompleteAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }

            return new MigrateResponse
            {
                CustomerCountOldDb = _oldContext.MstCustomers.Count(),
                CustomerCountNewDb = _newContext.MstCustomers.Count(),
                MigrationStatus = isSuccess
            };
        }

        [HttpGet]
        [Route("DownloadCustomerData")]
        public async Task<FileResult> DownloadCustomerData()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Customers_" + DateTime.Now + ".xlsx";
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Customers");

                    worksheet.Cell(1, 1).Value = "Customer_Row_Id";
                    worksheet.Cell(1, 2).Value = "Customer_Serial";
                    worksheet.Cell(1, 3).Value = "Name";
                    worksheet.Cell(1, 4).Value = "IsHof";
                    worksheet.Cell(1, 5).Value = "Age";
                    worksheet.Cell(1, 6).Value = "Address";
                    worksheet.Cell(1, 7).Value = "Family_Id";
                    worksheet.Cell(1, 8).Value = "Hof_Id";
                    worksheet.Cell(1, 9).Value = "Adhar_No";
                    worksheet.Cell(1, 10).Value = "Relation_With_Hof_Id";
                    worksheet.Cell(1, 11).Value = "Gaurdian_Name";
                    worksheet.Cell(1, 12).Value = "Gaurdian_Rel_Id";
                    worksheet.Cell(1, 13).Value = "Mobile_No";
                    worksheet.Cell(1, 14).Value = "CardNumber";
                    worksheet.Cell(1, 15).Value = "Card_Category_Id";
                    worksheet.Cell(1, 16).Value = "Active";
                    worksheet.Cell(1, 17).Value = "Created_Date";
                    worksheet.Cell(1, 18).Value = "Inactivated_Date";

                    int index = 1;
                    foreach(Repository.NewModels.MstCustomer cust in _newContext.MstCustomers)
                    {
                        worksheet.Cell(index + 1, 1).Value =
                        cust.CustomerRowId;
                        worksheet.Cell(index + 1, 2).Value =
                        cust.CustomerSerial;
                        worksheet.Cell(index + 1, 3).Value =
                        cust.Name;
                        worksheet.Cell(index + 1, 4).Value =
                        cust.IsHof;
                        worksheet.Cell(index + 1, 5).Value =
                        cust.Age;
                        worksheet.Cell(index + 1, 6).Value =
                        cust.Address;
                        worksheet.Cell(index + 1, 7).Value =
                        cust.FamilyId;
                        worksheet.Cell(index + 1, 8).Value =
                        cust.HofId;
                        worksheet.Cell(index + 1, 9).Value =
                        cust.AdharNo;
                        worksheet.Cell(index + 1, 10).Value =
                        cust.RelationWithHofId;
                        worksheet.Cell(index + 1, 11).Value =
                        cust.GaurdianName;
                        worksheet.Cell(index + 1, 12).Value =
                        cust.GaurdianRelId;
                        worksheet.Cell(index + 1, 13).Value =
                        cust.MobileNo;
                        worksheet.Cell(index + 1, 14).Value =
                        cust.CardNumber;
                        worksheet.Cell(index + 1, 15).Value =
                        cust.CardCategoryId;
                        worksheet.Cell(index + 1, 16).Value =
                        cust.Active;
                        worksheet.Cell(index + 1, 17).Value =
                        cust.CreatedDate;
                        worksheet.Cell(index + 1, 18).Value =
                        cust.InactivatedDate;

                        index++;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return File("", contentType, fileName);
        }

        [HttpGet]
        [Route("GetCustomerCount")]
        public async Task<int[]> GetCustomerCount()
        {
            return new int[] { _oldContext.MstCustomers.Count(), _newContext.MstCustomers.Count() };
        }
    }
}
