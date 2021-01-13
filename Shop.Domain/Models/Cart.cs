using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Models
{
    public class CartProduct
    {
        public int StockId { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
