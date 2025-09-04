using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalStoreManagement.Models;

namespace MedicalStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingsController : ControllerBase
    {
        private readonly MedicalStoreManagementContext _context;

        public PurchasingsController(MedicalStoreManagementContext context)
        {
            _context = context;
        }

        // GET: api/Purchasings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchasing>>> GetPurchasings()
        {
            return await _context.Purchasings.ToListAsync();
        }

        // GET: api/Purchasings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchasing>> GetPurchasing(int id)
        {
            var purchasing = await _context.Purchasings.FindAsync(id);

            if (purchasing == null)
            {
                return NotFound();
            }

            return purchasing;
        }

        // PUT: api/Purchasings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchasing(int id, Purchasing purchasing)
        {
            if (id != purchasing.PurchasingId)
            {
                return BadRequest();
            }

            _context.Entry(purchasing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Purchasings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Purchasing>> PostPurchasing(Purchasing purchasing)
        {
            _context.Purchasings.Add(purchasing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchasingExists(purchasing.PurchasingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchasing", new { id = purchasing.PurchasingId }, purchasing);
        }

        // DELETE: api/Purchasings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchasing(int id)
        {
            var purchasing = await _context.Purchasings.FindAsync(id);
            if (purchasing == null)
            {
                return NotFound();
            }

            _context.Purchasings.Remove(purchasing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchasingExists(int id)
        {
            return _context.Purchasings.Any(e => e.PurchasingId == id);
        }
    }
}
