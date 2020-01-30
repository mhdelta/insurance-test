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
    public class TiposCubrimientosController : ControllerBase
    {
        private readonly masterContext _context;

        public TiposCubrimientosController(masterContext context)
        {
            _context = context;
        }

        // GET: api/TiposCubrimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCubrimiento>>> GetTiposCubrimiento()
        {
            return await _context.TiposCubrimiento.ToListAsync();
        }

        // GET: api/TiposCubrimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCubrimiento>> GetTiposCubrimiento(int id)
        {
            var tiposCubrimiento = await _context.TiposCubrimiento.FindAsync(id);

            if (tiposCubrimiento == null)
            {
                return NotFound();
            }

            return tiposCubrimiento;
        }

        // PUT: api/TiposCubrimientos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposCubrimiento(int id, TipoCubrimiento tiposCubrimiento)
        {
            if (id != tiposCubrimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiposCubrimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposCubrimientoExists(id))
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

        // POST: api/TiposCubrimientos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TipoCubrimiento>> PostTiposCubrimiento(TipoCubrimiento tiposCubrimiento)
        {
            _context.TiposCubrimiento.Add(tiposCubrimiento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TiposCubrimientoExists(tiposCubrimiento.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTiposCubrimiento", new { id = tiposCubrimiento.Id }, tiposCubrimiento);
        }

        // DELETE: api/TiposCubrimientos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoCubrimiento>> DeleteTiposCubrimiento(int id)
        {
            var tiposCubrimiento = await _context.TiposCubrimiento.FindAsync(id);
            if (tiposCubrimiento == null)
            {
                return NotFound();
            }

            _context.TiposCubrimiento.Remove(tiposCubrimiento);
            await _context.SaveChangesAsync();

            return tiposCubrimiento;
        }

        private bool TiposCubrimientoExists(int id)
        {
            return _context.TiposCubrimiento.Any(e => e.Id == id);
        }
    }
}
