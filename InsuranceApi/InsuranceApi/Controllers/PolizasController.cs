using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceApi.Models;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly masterContext _context;

        public PolizasController(masterContext context)
        {
            _context = context;
        }

        // GET: api/Polizas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizas()
        {
            return await _context.Polizas.ToListAsync();
        }

        // GET: api/Polizas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poliza>> GetPolizas(int id)
        {
            var polizas = await _context.Polizas.FindAsync(id);

            if (polizas == null)
            {
                return NotFound();
            }

            return polizas;
        }

        // PUT: api/Polizas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolizas(int id, Poliza polizas)
        {
            if (id != polizas.Id)
            {
                return BadRequest();
            }

            _context.Entry(polizas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizasExists(id))
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

        // POST: api/Polizas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Poliza>> PostPolizas(Poliza polizas)
        {
            _context.Polizas.Add(polizas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PolizasExists(polizas.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPolizas", new { id = polizas.Id }, polizas);
        }

        // DELETE: api/Polizas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poliza>> DeletePolizas(int id)
        {
            var polizas = await _context.Polizas.FindAsync(id);
            if (polizas == null)
            {
                return NotFound();
            }

            _context.Polizas.Remove(polizas);
            await _context.SaveChangesAsync();

            return polizas;
        }

        private bool PolizasExists(int id)
        {
            return _context.Polizas.Any(e => e.Id == id);
        }
    }
}
