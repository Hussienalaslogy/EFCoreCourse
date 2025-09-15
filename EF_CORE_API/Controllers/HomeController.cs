using EF_CORE_API.Models;
using EF_CORE_API.Models2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace EF_CORE_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmarterASPContext _db;
        private readonly SmarterASPContext2 _db2;
        public HomeController(SmarterASPContext db , SmarterASPContext2 db2)
        {
            _db = db;
            _db2 = db2;
        }
        
        [HttpPost("TempPost")]
        public async Task<IActionResult> Temp([FromBody] CustomersAdresses customersAdresses)
        {
            await _db.AddAsync(customersAdresses);
            _db.SaveChanges();
            return Ok();
        }
        
        [HttpGet("SalesSummary")]
        public async Task<IActionResult> SalesSummary(DateTime start , DateTime end)
        {
            try
            {
                //Sales Summary per SalesMan
                var result = await _db2.SalesOrdersHeads
                    .Where(e => e.Type == "Sales Order" && e.Date >= start && e.Date < end)
                    .GroupBy(e => e.SalesMan)
                    .Select(g => new
                    {
                        SalesMan = g.Key,
                        OrdersCount = g.Count(),
                        OrdersAmount = g.Sum(x => x.Total),
                        TopOrderNo = g.OrderByDescending(x => x.Total).First().DocumentNo,
                        TopOrderValue = g.Max(x => x.Total),
                    })
                    .ToListAsync();

                var resultFinal = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);

                return Ok(resultFinal);

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

        [HttpGet("CustomerSummary")]
        public async Task<IActionResult> CustomerSummary(DateTime start, DateTime end)
        {
            try
            {
                var result = await _db2.SalesOrdersHeads
                    .Where(e => e.Type == "Sales Order" && e.Date >= start && e.Date < end)
                    .GroupBy(e => e.CustomerId)
                    .Select(g => new
                    {
                        CustomerName = g.First().CustomerEname,
                        SalesMan = g.First().SalesMan,
                        OrdersCount = g.Count(),
                        OrdersAmount = g.Sum(x => x.Total),
                        TopOrderNo = g.OrderByDescending(x => x.Total).First().DocumentNo,
                        TopOrderValue = g.Max(x => x.Total),
                    })
                    .ToListAsync();

                var resultFinal = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);

                return Ok(resultFinal);

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

        [HttpGet("CustomerTires")]
        public async Task<IActionResult> CustomerTires(DateTime start, DateTime end)
        {
            try
            {
                var result = await _db2.SalesOrdersHeads
                                .Where(e => e.Type == "Sales Order" && e.Date >= start && e.Date < end)
                                .GroupBy(e => e.CustomerId)
                                 .Select(g => new
                                 {
                                     CustomerName = g.First().CustomerEname,
                                     SalesMan = g.First().SalesMan,
                                     OrdersAmount = g.Sum(x => x.Total),
                                 })
                                 .GroupBy(e => e.SalesMan)
                                 .Select(g => new
                                 {
                                     SalesMan = g.Key,
                                     CustomersCount = g.Count(),
                                     Tier1 = g.Count(e => e.OrdersAmount < 1000),
                                     Tier2 = g.Count(e => e.OrdersAmount > 999 && e.OrdersAmount <= 9999),
                                     Tier3 = g.Count(e => e.OrdersAmount > 9999 && e.OrdersAmount <= 99999),
                                     Tier4 = g.Count(e => e.OrdersAmount > 99999)

                                 })
                                 .ToListAsync();

                var resultFinal = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);

                return Ok(resultFinal);

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
        public async Task<IActionResult> AddCustomer([FromBody] EF_CORE_API.Models.CustomersListH customer)
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
        public async Task<IActionResult> UpdateCustomer([FromBody] EF_CORE_API.Models.CustomersListH customer , string customerNo)
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


        public async Task<List<DTOs.LinesItems>> PrepareLinesItems(DateTime start, DateTime end)
        {
            var result = await _db2.SalesOrderLinesItems
               .AsNoTracking()
               .Where(e => e.DocumentNoNavigation.Type == "Sales Order")
               .Where(e => e.DocumentNoNavigation.Date > start && e.DocumentNoNavigation.Date <= end)
               .Select(g => new DTOs.LinesItems
               {
                   VendorNo = g.VendorNo,
                   ItemDescription = g.ItemDescription,
                   Quantity = g.Quantity,
                   UnitPrice = g.UnitPrice,
                   SoHeadId = g.DocumentNo,
                   SalesOrdersHead = g.DocumentNoNavigation
               })
               .ToListAsync();

            return result;
        }



    }
}
