using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Database;
using Shop.Application.Products;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;
        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        
        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }


        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }
    }
}
