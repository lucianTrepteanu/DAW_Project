using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Models
{
    public class CustomerInformation
    {
        [Required,MinLength(2,ErrorMessage = "First name too short")]
        public string FirstName { get; set; }
        [Required,MinLength(2,ErrorMessage = "Last name too short")]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress,ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber,ErrorMessage = "Phone number is invalid")]
        public string PhoneNumber { get; set; }

        [Required, MinLength(5,ErrorMessage = "Address too short")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required, MinLength(3)]
        public string City { get; set; }
        [Required, MinLength(5, ErrorMessage = "Invalid postcode")]
        public string PostCode { get; set; }
    }
}
