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
    public class MedcinineStocksController : ControllerBase
    {
        private readonly MedicalStoreManagementContext _context;

        public MedcinineStocksController(MedicalStoreManagementContext context)
        {
            _context = context;
        }

        // GET: api/MedcinineStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedcinineStock>>> GetMedcinineStocks()
        {
            return await _context.MedcinineStocks.ToListAsync();
        }

        // GET: api/MedcinineStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedcinineStock>> GetMedcinineStock(int id)
        {
            var medcinineStock = await _context.MedcinineStocks.FindAsync(id);

            if (medcinineStock == null)
            {
                return NotFound();
            }

            return medcinineStock;
        }

        // PUT: api/MedcinineStocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedcinineStock(int id, MedcinineStock medcinineStock)
        {
            if (id != medcinineStock.MedId)
            {
                return BadRequest();
            }

            _context.Entry(medcinineStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedcinineStockExists(id))
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

        // POST: api/MedcinineStocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedcinineStock>> PostMedcinineStock(MedcinineStock medcinineStock)
        {
            _context.MedcinineStocks.Add(medcinineStock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedcinineStockExists(medcinineStock.MedId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedcinineStock", new { id = medcinineStock.MedId }, medcinineStock);
        }

        // DELETE: api/MedcinineStocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedcinineStock(int id)
        {
            var medcinineStock = await _context.MedcinineStocks.FindAsync(id);
            if (medcinineStock == null)
            {
                return NotFound();
            }

            _context.MedcinineStocks.Remove(medcinineStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedcinineStockExists(int id)
        {
            return _context.MedcinineStocks.Any(e => e.MedId == id);
        }
    }
}
