using AutoMapper;
using CustomerRegistrationAndManagementSystem.Domain.Models;
using CustomerRegistrationAndManagementSystem.Domain.Services;
using CustomerRegistrationAndManagementSystem.Extensions;
using CustomerRegistrationAndManagementSystem.Resourses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable< CustomerResource>>(customers);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.UpdateAsync(id, customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }
    }
}