using AutoMapper;
using BusinessModel;
using Repository;
using Repository.Models;
using Repository.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RationcardRegisterWebApi
{
    public class OldDataMgmt
    {
        private readonly RationCardContext _oldContext;
        private readonly RationcardRegisterContext _newContext;
        private readonly IUnitOfWork _unitOfWork;
        private IDbRepository<Repository.NewModels.MstCustomer> _repository { get; set; }
        private readonly IMapper _mapper;

        public OldDataMgmt(RationCardContext oldContext, RationcardRegisterContext newContext
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _oldContext = oldContext;
            _newContext = newContext;
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Repository.NewModels.MstCustomer>();
            _mapper = mapper;
        }

        public async Task<List<Customer>> FetchCustomersNew()
        {
            var allCustDetails = new List<Customer>();
            try
            {
                allCustDetails = (from cust in _newContext.MstCustomers.DefaultIfEmpty()
                                 join cat in _newContext.MstCats
                                 on cust.CardCategoryId equals cat.CatId
                                 orderby cust.FamilyId ascending
                                 select new Customer
                                 {
                                     Active = cust.Active,
                                     Address = cust.Address,
                                     AdharNo = cust.AdharNo,
                                     Age = cust.Age ?? 0,
                                     CardCategory = cat.CatDesc,
                                     CardCategoryId = cat.CatId,
                                     Name = cust.Name,
                                     GaurdianName = cust.GaurdianName,
                                     GaurdianRelation = _newContext.MstRels.Where(r => r.MstRelId.Equals(cust.GaurdianRelId)).Select(r => r.Relation).FirstOrDefault(),
                                     GaurdianRelId = cust.GaurdianRelId,
                                     HofName = _newContext.MstCustomers.Where(r => r.CustomerSerial.Equals(cust.HofId)).Select(r => r.Name).FirstOrDefault(),
                                     RelationWithHofId = cust.RelationWithHofId,
                                     RelationWithHof = _newContext.MstRels.Where(r => r.MstRelId.Equals(cust.RelationWithHofId)).Select(r => r.Relation).FirstOrDefault(),
                                     IsHof = cust.IsHof,
                                     HofId = cust.HofId,
                                     InactivatedDate = cust.InactivatedDate,
                                     MobileNo = cust.MobileNo,
                                     CustomerSerial = cust.CustomerSerial,
                                     CardNumber = cust.CardNumber,                                     
                                     CreatedDate = cust.CreatedDate,
                                     CustomerRowId = cust.CustomerRowId,                                     
                                     FamilyId = cust.FamilyId                                     
                                 }).ToList();
            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }

        public async Task<List<Customer>> FetchDataOld()
        {
            var allCustDetails = new List<Customer>();
            try
            {
                int custSerial = 1;
                var allCusts = (from oldCust in _oldContext.MstCustomers
                                join oldCard in _oldContext.TxnRationCards
                               on new { custIdEqualType = oldCust.CustomerId, cardIdEqualType = oldCust.RationCardId }
                               equals new { custIdEqualType = (oldCard.CustomerId ?? 0), cardIdEqualType = oldCard.RationCardId.ToString() }                               
                               into customers
                                from cust in customers.DefaultIfEmpty()
                                join cat in _oldContext.MstCats
                                on cust.CardCategoryId equals cat.CatId                                
                                select new Customer
                                {
                                    Active = cust.Active,
                                    Address = oldCust.Address,
                                    AdharNo = oldCust.AdharNo,
                                    Age = oldCust.Age ?? 0,
                                    CardCategoryId = cat.CatId,
                                    CardCategory = cat.CatKey,
                                    Name = oldCust.Name,
                                    GaurdianName = oldCust.GaurdianName,
                                    GaurdianRelId = _oldContext.MstRels.Where(r => r.Relation.Equals(oldCust.GaurdianRelation)).Select(r => r.MstRelWithHofId).FirstOrDefault(),
                                    IsHof = oldCust.HofFlag,
                                    HofId = oldCust.HofId,
                                    HofName = _oldContext.MstCustomers.Where(r => r.CustomerId.Equals(oldCust.HofId)).Select(r => r.Name).FirstOrDefault(),
                                    InactivatedDate = oldCust.InactivatedDate,
                                    MobileNo = oldCust.MobileNo,
                                    CardNumber = cust.Number,
                                    RelationWithHofId = _oldContext.MstRels.Where(r => r.Relation.Equals(oldCust.RelationWithHof)).Select(r => r.MstRelWithHofId).FirstOrDefault(),
                                    CreatedDate = oldCust.CreatedDate,
                                    FamilyId = 0,                                    
                                    GaurdianRelation = oldCust.GaurdianRelation,                                    
                                    RelationWithHof = oldCust.RelationWithHof,
                                    CustomerRowId = cust.CustomerId??0
                                }).ToList();

                allCusts.ForEach(c =>
                {
                    c.GaurdianRelId = (c.GaurdianRelId == 0) ? 19 : c.GaurdianRelId;
                    c.RelationWithHofId = (c.RelationWithHofId == 0) ? 19 : c.RelationWithHofId;

                    //recreate Customer Serial as that is the unique key to every record
                    c.CustomerSerial = custSerial;
                    custSerial++;
                });
                //hofid
                allCusts.ForEach(c =>
                {
                    //Correcting hofid as those old id's are from old system and those are actually identity column value
                    //So we have taken customerid old into CustomerRowId in above query and now we will be finding 
                    //record with that old customerid which is stored in CustomerRowId
                    //Then replace hofid with CustomerSerial of that record
                    c.HofId = allCusts.Where(r => r.CustomerRowId.Equals(c.HofId)).FirstOrDefault()?.CustomerSerial;
                });
                //Assign FamilyId
                int familyId = 1;
                var familyGrp = from cust in allCusts
                        group cust by cust.HofId;
                foreach(var cGrp in familyGrp)
                {
                    foreach(Customer cu in cGrp)
                    {
                        cu.FamilyId = familyId;
                        cu.CustomerRowId = default(int);
                    }
                    familyId++;
                }

                allCustDetails = allCusts;
            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }

        public int? UpdateMstRel(int rel)
        {
            return (rel == 0) ? 19 : rel;
        }
    }
}
