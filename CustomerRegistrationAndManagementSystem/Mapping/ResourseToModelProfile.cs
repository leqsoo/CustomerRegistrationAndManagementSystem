using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerRegistrationAndManagementSystem.Domain.Models;
using CustomerRegistrationAndManagementSystem.Resourses;

namespace CustomerRegistrationAndManagementSystem.Mapping
{
    public class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<SaveCustomerResource, Customer>();
        }
    }
}
