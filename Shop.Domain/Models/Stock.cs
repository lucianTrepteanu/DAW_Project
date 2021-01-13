using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        [Required, MinLength(5,ErrorMessage ="Description is too short")]
        public String Description { get; set; }
        [Required]
        public int Qty { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<OrderStock> OrderStocks { get; set; }
    }
}
