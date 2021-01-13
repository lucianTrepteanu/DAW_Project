using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string StripeReference { get; set; }

        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required, MinLength(3), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(7), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostCode { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderStock> OrderStocks { get; set; }
    }
}
