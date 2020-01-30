using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceApi.Models;
using InsuranceApi.Repositories;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaRepository _repository;

        public PolizasController(IPolizaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliza>>> Get()
        {
            return await _repository.FindAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Poliza>> GetById(int id)
        {
            var poliza = _repository.Find(id);

            if (poliza == null)
            {
                return NotFound();
            }

            return poliza;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Poliza>> post(Poliza poliza)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return BadRequest();
                }
                _repository.Create(poliza);
            }
            catch (DbUpdateException)
            {
                if (dataExists(poliza.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e) {
                return StatusCode(405, e.InnerException);
            }

            return CreatedAtAction("Get", new { id = poliza.Id }, poliza);
        }

        [HttpPut("{id}")]
        public ActionResult<Poliza> put([FromQuery] Poliza poliza, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Update(poliza);
            return poliza;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Poliza>> Delete(int id)
        {
            var poliza = _repository.Find(id);
            if (poliza == null)
            {
                return NotFound();
            }

            _repository.Delete(poliza);

            return poliza;
        }

        private bool dataExists(int id)
        {
            return _repository.Find(id) != null;
        }
    }
}
