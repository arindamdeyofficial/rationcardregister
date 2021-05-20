using BusinessModel;
using Repository.Models;
using Repository.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<Customer> FetchCustomersOld(int noOfCustomers)
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
                        Name = combinedEntry.cust.Name,
                        GaurdianName = combinedEntry.cust.GaurdianName,
                        GaurdianRelation = combinedEntry.cust.GaurdianRelation,
                        Ishof = combinedEntry.cust.HofFlag,
                        HofId = combinedEntry.cust.HofId,
                        InactivatedDate = combinedEntry.cust.InactivatedDate,
                        MobileNo = combinedEntry.cust.MobileNo,
                        SerialNumber = combinedEntry.cust.CustomerId,
                        RationcardNumber = combinedEntry.card.Number,
                        RelationWithHof = combinedEntry.cust.RelationWithHof,
                        CreatedDate = combinedEntry.card.CreatedDate,
                        CustomerId = combinedEntry.cust.CustomerId,
                        FamilyId = 0
                    }).ToList();

            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }

        public List<Customer> FetchCustomersNew()
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
                                     GaurdianRelation = relGuardian.Relation,
                                     Ishof = cust.IsHof,
                                     HofId = cust.HofId,
                                     InactivatedDate = cust.InactivatedDate,
                                     MobileNo = cust.MobileNo,
                                     SerialNumber = cust.CustomerSerial ?? 0,
                                     RationcardNumber = cust.CardNumber,
                                     RelationWithHof = relHof.Relation,
                                     CreatedDate = cust.CreatedDate,
                                     CustomerId = cust.CustomerRowId,
                                     FamilyId = 0
                                 }).ToList();


            }
            catch (Exception ex)
            {
                return allCustDetails;
            }
            return allCustDetails;
        }

        public List<Repository.NewModels.MstCustomer> FetchDataRaw()
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

                 allCustDetails = (from oldCust in _oldContext.MstCustomers.DefaultIfEmpty()
                                   join oldCard in _oldContext.TxnRationCards.DefaultIfEmpty()
                                 on oldCust.CustomerId equals oldCard.CustomerId into customers
                                   from cust in customers.DefaultIfEmpty()
                                   join cat in _oldContext.MstCats
                                  on cust.CardCategoryId equals cat.CatId
                                   join rel in _oldContext.MstRels
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
                                       CardNumber = "",
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
