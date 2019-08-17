using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRegistrationAndManagementSystem.Domain.Models;

namespace CustomerRegistrationAndManagementSystem.Domain.Services.Communication
{
    public class SaveCustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }

        public SaveCustomerResponse(bool success, string message, Customer customer)
            : base(success, message)
        {
            Customer = customer;
        }

        /// <summary>
        /// Creates a Sucsses Response.
        /// </summary>
        /// <param name="customer">Saved Customer.</param>
        /// <returns>Response.</returns>
        public SaveCustomerResponse(Customer customer)
            : this(true, string.Empty, customer)
        {

        }

        /// <summary>
        /// Creates an Error Response
        /// </summary>
        /// <param name="message">Error Message.</param>
        /// <returns>Response.</returns>
        public SaveCustomerResponse(string message)
            : this(false, message, null)
        {

        }
    }
}
