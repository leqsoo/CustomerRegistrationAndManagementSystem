using AutoMapper;
using CustomerRegistrationAndManagementSystem.Domain.Models;
using CustomerRegistrationAndManagementSystem.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();
        }
    }
}
