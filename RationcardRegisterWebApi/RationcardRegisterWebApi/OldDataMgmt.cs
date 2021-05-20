using BusinessModel;
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
        public OldDataMgmt(RationCardContext oldContext, RationcardRegisterContext newContext)
        {
            _oldContext = oldContext;
            _newContext = newContext;
        }
        public async Task<List<Customer>> FetchCustomersOld(int noOfCustomers)
        {
            var allCustDetails = new List<Customer>();
            try
            {
                //string ConStrVal = _configuration.GetValue<string>("AzureSQLConnectionString");
                //string conStr = (ConStrVal == "") ? connectionStr : ConStrVal;
                //_services.AddDbContextPool<RationCardContext>(options => options.UseSqlServer(conStr));

                allCustDetails = _oldContext.MstCustomers
                    .Where(a => a.CustomerId < noOfCustomers)
                   .Join(_oldContext.TxnRationCards,
                   cust => cust.RationCardId,
                   card => card.RationCardId.ToString(),
                   (cust, card) => new { cust, card })
                   .Join(_oldContext.MstCats,
                   combinedEntry => combinedEntry.card.CardCategoryId,
                   cat => cat.CatId,
                   (combinedEntry, cat) =>new Customer
                    {
                        Active = combinedEntry.cust.Active,
                        Address = combinedEntry.cust.Address,
                        AdharNo = combinedEntry.cust.AdharNo,
                        Age = combinedEntry.cust.Age ?? 0,
                        CardCategory = cat.CatKey,
                        CardCategoryId = cat.CatId,
                        Name = combinedEntry.cust.Name,
                        GaurdianName = combinedEntry.cust.GaurdianName,
                        GaurdianRelation = combinedEntry.cust.GaurdianRelation,
                        IsHof = combinedEntry.cust.HofFlag,
                        HofId = combinedEntry.cust.HofId,
                        InactivatedDate = combinedEntry.cust.InactivatedDate,
                        MobileNo = combinedEntry.cust.MobileNo,
                        CustomerSerial = combinedEntry.cust.CustomerId,
                        CardNumber = combinedEntry.card.Number,
                        RelationWithHof = combinedEntry.cust.RelationWithHof,
                       CreatedDate = combinedEntry.card.CreatedDate,
                        CustomerRowId = combinedEntry.cust.CustomerId,
                        FamilyId = 0                     
                    }).ToList();

            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }

        public async Task<List<Customer>> FetchCustomersNew()
        {
            var allCustDetails = new List<Customer>();
            try
            {
                allCustDetails = (from cust in _newContext.MstCustomers.DefaultIfEmpty()
                                 join cat in _newContext.MstCats
                                 on cust.CardCategoryId equals cat.CatId
                                 join relGuardian in _newContext.MstRels
                                 on cust.GaurdianRelId equals relGuardian.MstRelId
                                 join relHof in _newContext.MstRels
                                 on cust.RelationWithHofId equals relHof.MstRelId
                                 select new Customer
                                 {
                                     Active = cust.Active,
                                     Address = cust.Address,
                                     AdharNo = cust.AdharNo,
                                     Age = cust.Age ?? 0,
                                     CardCategory = cat.CatDesc,
                                     Name = cust.Name,
                                     GaurdianName = cust.GaurdianName,
                                     GaurdianRelId = cust.GaurdianRelId ?? 0,
                                     GaurdianRelation = relGuardian.Relation,
                                     IsHof = cust.IsHof,
                                     HofId = cust.HofId,
                                     InactivatedDate = cust.InactivatedDate,
                                     MobileNo = cust.MobileNo,
                                     CustomerSerial = cust.CustomerSerial ?? 0,
                                     CardNumber = cust.CardNumber,
                                     RelationWithHof = relHof.Relation,
                                     RelationWithHofId = relHof.MstRelId,
                                     CardCategoryId = cat.CatId,
                                     CreatedDate = cust.CreatedDate,
                                     CustomerRowId = cust.CustomerRowId,
                                     FamilyId = 0
                                 }).ToList();


            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }

        public async Task<List<Repository.NewModels.MstCustomer>> FetchDataRaw()
        {
            var allCustDetails = new List<Repository.NewModels.MstCustomer>();
            try
            {
                //string ConStrVal = _configuration.GetValue<string>("AzureSQLConnectionString");
                //string conStr = (ConStrVal == "") ? connectionStr : ConStrVal;
                //_services.AddDbContextPool<RationCardContext>(options => options.UseSqlServer(conStr));

                //var allCards = (from oldCust in _oldContext.MstCustomers
                //                join oldCard in _oldContext.TxnRationCards
                //               on new { custIdEqualType = oldCust.CustomerId, cardIdEqualType = oldCust.RationCardId }
                //               equals new { custIdEqualType = (oldCard.CustomerId ?? 0), cardIdEqualType = oldCard.RationCardId.ToString() }
                //               into customers
                //               from cust in customers
                //               join cat in _oldContext.MstCats
                //               on cust.CardCategoryId equals cat.CatId
                //                join rel in _oldContext.MstRels
                //                //on (oldCust.GaurdianRelation ?? string.Empty).Trim().ToLower() equals (rel.Relation ?? string.Empty).Trim().ToLower()
                //                on cust.GaurdianRelation equals rel.Relation
                //                select oldCust.RationCardId).ToList();

                 allCustDetails = (from oldCust in _oldContext.MstCustomers
                                   join oldCard in _oldContext.TxnRationCards
                                  on new { custIdEqualType = oldCust.CustomerId, cardIdEqualType = oldCust.RationCardId }
                                  equals new { custIdEqualType = (oldCard.CustomerId ?? 0), cardIdEqualType = oldCard.RationCardId.ToString() }
                                  into customers
                                   from cust in customers
                                   join cat in _oldContext.MstCats
                                   on cust.CardCategoryId equals cat.CatId
                                   join rel in _oldContext.MstRels
                                   //on (oldCust.GaurdianRelation ?? string.Empty).Trim().ToLower() equals (rel.Relation ?? string.Empty).Trim().ToLower()
                                   on oldCust.GaurdianRelation equals rel.Relation
                                   select new Repository.NewModels.MstCustomer
                                   {
                                       Active = oldCust.Active,
                                       Address = oldCust.Address,
                                       AdharNo = oldCust.AdharNo,
                                       Age = oldCust.Age ?? 0,
                                       CardCategoryId = cat.CatId,
                                       Name = oldCust.Name,
                                       GaurdianName = oldCust.GaurdianName,
                                       GaurdianRelId = rel.MstRelWithHofId,
                                       IsHof = oldCust.HofFlag,
                                       HofId = oldCust.HofId,
                                       InactivatedDate = oldCust.InactivatedDate,
                                       MobileNo = oldCust.MobileNo,
                                       CustomerSerial = oldCust.CustomerId,
                                       CardNumber = cust.Number,
                                       RelationWithHofId = rel.MstRelWithHofId,
                                       CreatedDate = DateTime.Now,
                                       FamilyId = 0
                                   }).ToList();

            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }
    }
}
