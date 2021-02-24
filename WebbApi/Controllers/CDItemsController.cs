using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebbApi.Data;
using WebbApi.Models;

namespace WebbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDItemsController : ControllerBase
    {
        private readonly CDItemContext _context;

        public CDItemsController(CDItemContext context)
        {
            _context = context;
        }

        // GET: api/CDItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CDItem>>> GetCDS()
        {
            return await _context.CDS.ToListAsync();
        }

        // GET: api/CDItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CDItem>> GetCDItem(int id)
        {
            var cDItem = await _context.CDS.FindAsync(id);

            if (cDItem == null)
            {
                return NotFound();
            }

            return cDItem;
        }

        // PUT: api/CDItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCDItem(int id, CDItem cDItem)
        {
            if (id != cDItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(cDItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDItemExists(id))
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

        // POST: api/CDItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CDItem>> PostCDItem(CDItem cDItem)
        {
            _context.CDS.Add(cDItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCDItem", new { id = cDItem.ID }, cDItem);
        }

        // DELETE: api/CDItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCDItem(int id)
        {
            var cDItem = await _context.CDS.FindAsync(id);
            if (cDItem == null)
            {
                return NotFound();
            }

            _context.CDS.Remove(cDItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CDItemExists(int id)
        {
            return _context.CDS.Any(e => e.ID == id);
        }
    }
}
