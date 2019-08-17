using AutoMapper;
using CustomerRegistrationAndManagementSystem.Domain.Models;
using CustomerRegistrationAndManagementSystem.Domain.Repositories;
using CustomerRegistrationAndManagementSystem.Domain.Services;
using CustomerRegistrationAndManagementSystem.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Helpers;

namespace CustomerRegistrationAndManagementSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<SaveCustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();

                return new SaveCustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new SaveCustomerResponse($"An Error occured while saving the Customer {ex.Message}");
            }
        }

        public async Task<SaveCustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new SaveCustomerResponse("Customer Not Found");

            var exiexistingCustomerId = existingCustomer.Id;
            _mapper.Map(customer, existingCustomer);
            existingCustomer.Id = exiexistingCustomerId;
            existingCustomer.Password = Cryptography.Encrypt(existingCustomer.Password, "MyEncryption");
            try
            {
                _customerRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new SaveCustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new SaveCustomerResponse($"An Error occured While updating Customer: {ex.Message}");
            }
        }
    }
}
