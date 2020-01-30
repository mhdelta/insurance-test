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
    public class TiposRiesgosController : ControllerBase
    {
        private readonly masterContext _context;

        public TiposRiesgosController(masterContext context)
        {
            _context = context;
        }

        // GET: api/TiposRiesgos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRiesgo>>> GetTiposRiesgo()
        {
            return await _context.TiposRiesgo.ToListAsync();
        }

        // GET: api/TiposRiesgos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRiesgo>> GetTiposRiesgo(int id)
        {
            var tiposRiesgo = await _context.TiposRiesgo.FindAsync(id);

            if (tiposRiesgo == null)
            {
                return NotFound();
            }

            return tiposRiesgo;
        }

        // PUT: api/TiposRiesgos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposRiesgo(int id, TipoRiesgo tiposRiesgo)
        {
            if (id != tiposRiesgo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiposRiesgo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposRiesgoExists(id))
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

        // POST: api/TiposRiesgos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TipoRiesgo>> PostTiposRiesgo(TipoRiesgo tiposRiesgo)
        {
            _context.TiposRiesgo.Add(tiposRiesgo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TiposRiesgoExists(tiposRiesgo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTiposRiesgo", new { id = tiposRiesgo.Id }, tiposRiesgo);
        }

        // DELETE: api/TiposRiesgos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoRiesgo>> DeleteTiposRiesgo(int id)
        {
            var tiposRiesgo = await _context.TiposRiesgo.FindAsync(id);
            if (tiposRiesgo == null)
            {
                return NotFound();
            }

            _context.TiposRiesgo.Remove(tiposRiesgo);
            await _context.SaveChangesAsync();

            return tiposRiesgo;
        }

        private bool TiposRiesgoExists(int id)
        {
            return _context.TiposRiesgo.Any(e => e.Id == id);
        }
    }
}
