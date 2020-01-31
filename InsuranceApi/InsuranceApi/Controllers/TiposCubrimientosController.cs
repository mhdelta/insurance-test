using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceApi.Models;
using InsuranceApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposCubrimientosController : ControllerBase
    {
        private readonly ITipoCubrimientoRepository _repository;

        public TiposCubrimientosController(ITipoCubrimientoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCubrimiento>>> Get()
        {
            return await _repository.FindAll().ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TipoCubrimiento>> GetById(int id)
        {
            var tipoCubrimiento = _repository.Find(id);

            if (tipoCubrimiento == null)
            {
                return NotFound();
            }

            return tipoCubrimiento;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TipoCubrimiento>> post(TipoCubrimiento tipoCubrimiento)
        {
            try
            {
                _repository.Create(tipoCubrimiento);
            }
            catch (DbUpdateException)
            {
                if (dataExists(tipoCubrimiento.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = tipoCubrimiento.Id }, tipoCubrimiento);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<TipoCubrimiento>> Delete(int id)
        {
            var tipoCubrimiento = _repository.Find(id);
            if (tipoCubrimiento == null)
            {
                return NotFound();
            }

            _repository.Delete(tipoCubrimiento);

            return tipoCubrimiento;
        }

        private bool dataExists(int id)
        {
            return _repository.Find(id) != null;
        }
    }
}
