using AutoMapper;
using BusinessModel;
using Repository.Models;
using Repository.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RationcardRegisterWebApi
{
    public class AutoMapperProfile: Profile
    {
        private MapperConfiguration _config;
        public AutoMapperProfile()
        {
             CreateMap<Customer, Repository.NewModels.MstCustomer>().ReverseMap();
        }
        
    }
}
