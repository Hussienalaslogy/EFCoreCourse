using EF_CORE_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmarterASPContext _db;
        public HomeController(SmarterASPContext db)
        {
            _db = db;
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var customer = await _db.CustomersListHs
               .AsNoTracking()
               .Where(e => e.CustomerNo.StartsWith("R"))
               .Select(e => new
               {
                   e.CustomerNo,
                   e.CustomerName
               })
               .ToListAsync();

                if (!customer.Any()) { return NotFound(); }

                return Ok(customer);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
