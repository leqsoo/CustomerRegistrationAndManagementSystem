using AutoMapper;
using CustomerRegistrationAndManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Mapping
{
    public class UpdateMappingProfile : Profile
    {
        public UpdateMappingProfile()
        {
            CreateMap<Customer, Customer>();
        }
    }
}
