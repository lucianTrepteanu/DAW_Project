using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Application.Cart
{
    public class AddCustomerInformation
    {
        private ISession _session;

        public AddCustomerInformation(ISession session)
        {
            _session = session;
        }

        public class Request
        {
            [Required, MinLength(2, ErrorMessage = "First name too short")]
            public string FirstName { get; set; }
            [Required ,MinLength(2, ErrorMessage = "Last name too short")]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            [RegularExpression(@"^07(\d{8})$", ErrorMessage = "Invalid phone number")]
            public string PhoneNumber { get; set; }


            [Required,MinLength(5, ErrorMessage = "Address too short")]
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            [Required,MyValidation]
            public string City { get; set; }
            [Required, MinLength(5, ErrorMessage = "Invalid postcode")]
            public string PostCode { get; set; }
        }

        public void Do(Request request)
        {
            var customerInformation = new CustomerInformation
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                PostCode = request.PostCode
            };

            var stringObject = JsonConvert.SerializeObject(customerInformation);

            _session.SetString("customer-info", stringObject);
        }
    }
}
