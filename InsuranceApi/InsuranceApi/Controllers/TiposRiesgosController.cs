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
    public class TiposRiesgosController : ControllerBase
    {
        private readonly ITipoRiesgoRepository _repository;

        public TiposRiesgosController(ITipoRiesgoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRiesgo>>> Get()
        {
            return await _repository.FindAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRiesgo>> GetById(int id)
        {
            var tipoRiesgo = _repository.Find(id);

            if (tipoRiesgo == null)
            {
                return NotFound();
            }

            return tipoRiesgo;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TipoRiesgo>> post(TipoRiesgo tipoRiesgo)
        {
            try
            {
                _repository.Create(tipoRiesgo);
            }
            catch (DbUpdateException)
            {
                if (dataExists(tipoRiesgo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = tipoRiesgo.Id }, tipoRiesgo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoRiesgo>> Delete(int id)
        {
            var tipoRiesgo = _repository.Find(id);
            if (tipoRiesgo == null)
            {
                return NotFound();
            }

            _repository.Delete(tipoRiesgo);

            return tipoRiesgo;
        }

        private bool dataExists(int id)
        {
            return _repository.Find(id) != null;
        }
    }
}
