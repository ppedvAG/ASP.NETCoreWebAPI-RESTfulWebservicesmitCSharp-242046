using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Northwind.Access.Models;

namespace M009_OData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ODataController
    {
        private readonly NorthwindDbContext _context;

        public CustomersController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet, EnableQuery]
        [Route("Customers")]
        public IActionResult Get()
        {
            return Ok(_context.Customers.ToList());
        }

        [HttpGet, EnableQuery]
        [Route("Customers/{key}")]
        public IActionResult Get(int key)
        {
            var item = _context.Customers.SingleOrDefault(d => d.CustomerId.Equals(key));
            return item != null ? Ok(item) : NotFound();
        }
    }
}
