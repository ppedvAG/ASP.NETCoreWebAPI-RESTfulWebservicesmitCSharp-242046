using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Northwind.Access.Models;

namespace M009_OData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ODataController
    {
        private readonly NorthwindDbContext _context;

        public EmployeesController(NorthwindDbContext context)
        {
            _context = context;
        }

        [HttpGet, EnableQuery]
        [Route("Employees")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpGet, EnableQuery]
        [Route("Employees/{key}")]
        public ActionResult<Employee> Get([FromRoute] int key)
        {
            var item = _context.Employees.SingleOrDefault(d => d.EmployeeId.Equals(key));
            return item != null ? Ok(item) : NotFound();
        }
    }
}
