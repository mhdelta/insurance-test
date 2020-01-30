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
    public class PolizasClientesController : ControllerBase
    {
        private readonly masterContext _context;

        public PolizasClientesController(masterContext context)
        {
            _context = context;
        }

        // GET: api/PolizasClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolizaCliente>>> GetPolizasCliente()
        {
            return await _context.PolizasCliente.ToListAsync();
        }

        // GET: api/PolizasClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolizaCliente>> GetPolizasCliente(int id)
        {
            var polizasCliente = await _context.PolizasCliente.FindAsync(id);

            if (polizasCliente == null)
            {
                return NotFound();
            }

            return polizasCliente;
        }

        // PUT: api/PolizasClientes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolizasCliente(int id, PolizaCliente polizasCliente)
        {
            if (id != polizasCliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(polizasCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizasClienteExists(id))
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

        // POST: api/PolizasClientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PolizaCliente>> PostPolizasCliente(PolizaCliente polizasCliente)
        {
            _context.PolizasCliente.Add(polizasCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PolizasClienteExists(polizasCliente.IdCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPolizasCliente", new { id = polizasCliente.IdCliente }, polizasCliente);
        }

        // DELETE: api/PolizasClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PolizaCliente>> DeletePolizasCliente(int id)
        {
            var polizasCliente = await _context.PolizasCliente.FindAsync(id);
            if (polizasCliente == null)
            {
                return NotFound();
            }

            _context.PolizasCliente.Remove(polizasCliente);
            await _context.SaveChangesAsync();

            return polizasCliente;
        }

        private bool PolizasClienteExists(int id)
        {
            return _context.PolizasCliente.Any(e => e.IdCliente == id);
        }
    }
}
