using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Northwind.Access.Models;

namespace M009_OData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ODataController
    {
        private readonly NorthwindDbContext _context;

        public OrdersController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet, EnableQuery]
        [Route("Orders")]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_context.Orders.ToList());
        }

        [HttpGet, EnableQuery]
        [Route("Orders/{key}")]
        public ActionResult<Order> Get([FromRoute] int key)
        {
            var item = _context.Orders.SingleOrDefault(d => d.OrderId.Equals(key));
            return item != null ? Ok(item) : NotFound();
        }
    }
}
