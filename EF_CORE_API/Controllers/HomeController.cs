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
        
        [HttpPost("TempPost")]
        public async Task<IActionResult> Temp([FromBody] CustomersAdresses customersAdresses)
        {
            await _db.AddAsync(customersAdresses);
            _db.SaveChanges();
            return Ok();
        }
        
        [HttpGet("TempGet")]
        public async Task<IActionResult> TempGet(string param)
        {
            var docList = await _db.CustomersListH
                .Where(e => e.CustomerNo == param)
                .Select(e => e.SalesOrderHeads.Where(o => o.Type == "Sales Order"))
                .SelectMany(e => e)
                .Select( e => new
                {
                    e.DocumentNo,
                    e.Total
                })
                .ToListAsync();

            var docList2 = await _db.CustomersListH
               .Where(e => e.CustomerNo == param)
               .SelectMany(e => e.SalesOrderHeads)
               .Where(e => e.Type == "Sales Order")
               .Select(e => new
               {
                   e.DocumentNo,
                   e.Total
               })
               .ToListAsync();

            return Ok(docList2);
        }






        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(string param)
        {
            try
            {
                var customer = await _db.CustomersListH
               .AsNoTracking()
               .Where(e => e.CustomerNo == param)
               .Select(e => new
               {
                   e.CustomerNo,
                   e.CustomerName,
                   e.CustomerEname,
                   e.SalesMan,
                   e.MobileNo,
                   e.Adress
               })
               .ToListAsync();

                if (!customer.Any()) { return NotFound("Can't Find Any Customer With This Customer No"); }

                return Ok(customer);
            }
            catch (DbUpdateException ex)
            {
                string innerMsg = ex.InnerException?.Message ?? string.Empty;
                string msg = string.IsNullOrEmpty(innerMsg) ? ex.Message : innerMsg;
                return BadRequest($"EF Core Error: {msg}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
            }
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomersListH customer)
        {
            if (customer == null)
            {
                return BadRequest("Wrong Sent Data");
            }

            try
            {
                _db.CustomersListH.Add(customer);
                await _db.SaveChangesAsync();
                return Ok("Customer Saved Successfully");
            }
            catch (DbUpdateException ex)
            {
                string innerMsg = ex.InnerException?.Message ?? string.Empty;
                string msg = string.IsNullOrEmpty(innerMsg) ? ex.Message : innerMsg;
                return BadRequest($"EF Core Error: {msg}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomersListH customer , string customerNo)
        {
            if (customer == null) return BadRequest("No Data ToUpdate");

            try
            {
                var existCustomer = await _db.CustomersListH
                    .FindAsync(customerNo);

                if(existCustomer != null)
                {
                    existCustomer.CustomerName = customer.CustomerName;
                    existCustomer.CustomerEname = customer.CustomerEname;
                    existCustomer.SalesMan = customer.SalesMan;
                    existCustomer.MobileNo = customer.MobileNo;

                    await _db.SaveChangesAsync();
                    return Ok("Customer Updated Successfully");
                }
                else
                {
                    return NotFound("Customer Not Found");
                }
            }
            catch (DbUpdateException ex)
            {
                string innerMsg = ex.InnerException?.Message ?? string.Empty;
                string msg = string.IsNullOrEmpty(innerMsg) ? ex.Message : innerMsg;
                return BadRequest($"EF Core Error: {msg}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
            }
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(string customerNo)
        {
            if (string.IsNullOrWhiteSpace(customerNo)) return BadRequest("CustomerNo Is Required");

            try
            {
                var customer = await _db.CustomersListH
                    .FindAsync (customerNo);

                if(customer != null)
                {
                    _db.Remove(customer);
                    await _db.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    return NotFound("Customer Not Found");
                }
            }
            catch(DbUpdateException ex)
            {
                string innerMsg = ex.InnerException?.Message ?? string.Empty;
                string msg = string.IsNullOrEmpty(innerMsg) ? ex.Message : innerMsg;
                return BadRequest($"EF Core Error: {msg}");
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
            }
        }

        [HttpGet("GetLastNo")]
        public async Task<IActionResult> GetLastNo(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                return BadRequest("Prefix Is Required");
            }

            var Codes = await _db.CustomersListH
                .Where(e => e.CustomerNo.StartsWith(prefix))
                .Select(e => int.Parse(e.CustomerNo.Substring(prefix.Length)))
                .ToHashSetAsync();


            if (Codes.Count == 0)
            {
                return Ok(1);
            }
            else
            {
                int start = Codes.Min();
                int end = Codes.Max();

                for (int i = start; i <= end; i++)
                {
                    if (!Codes.Contains(i))
                    {
                        return Ok(i);
                    }
                }

                return Ok(end + 1);
            }
        }
    }
}
