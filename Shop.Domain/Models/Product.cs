using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MinLength(4,ErrorMessage = "Product name is too short")]
        public string Name { get; set; }
        [Required, MinLength(10,ErrorMessage = "Description is too short")]
        public string Description { get; set; }
        [Required]
        public decimal Value { get; set; }

        public ICollection<Stock> Stock { get; set; }
        public string ImageURL { get; set; }
    }
}
