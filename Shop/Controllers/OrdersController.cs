using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders;
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
        [HttpGet("")]
        public IActionResult GetOrders(int status,
            [FromServices] GetOrders getOrders) => Ok(getOrders.Do(status));
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id,
            [FromServices] GetOrder getOrder) => Ok(getOrder.Do(id));
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id,
            [FromServices] UpdateOrder updateOrder) => Ok((await updateOrder.DoAsync(id)));
    }
}
