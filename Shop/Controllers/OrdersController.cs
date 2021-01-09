using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _ctx;

        public OrdersController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        //TODO:
    }
}
