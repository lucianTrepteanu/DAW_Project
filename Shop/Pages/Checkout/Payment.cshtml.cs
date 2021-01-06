using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Shop.Application.Cart;
using Shop.Database;
using Stripe;

namespace ShopUI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public string PublicKey { get; }

        private ApplicationDbContext _ctx;

        public PaymentModel(IConfiguration config, ApplicationDbContext ctx)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
            _ctx = ctx;
        }
        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();
            if(information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public IActionResult OnPost(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var CardOrder = new GetOrder(HttpContext.Session, _ctx).Do();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = CardOrder.GetTotalCharge(),
                Description = "Shop Purchase",
                Currency = "usd",
                Customer = customer.Id
            }) ;

            return RedirectToPage("/Index");
        }
    }
}
