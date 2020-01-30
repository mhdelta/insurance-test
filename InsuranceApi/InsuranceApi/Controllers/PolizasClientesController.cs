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
    public class PolizasClientesController : ControllerBase
    {
        private readonly IPolizaClienteRepository _repository;

        public PolizasClientesController(IPolizaClienteRepository repository)
        {
            _repository = repository;
        }

        // POST: api/Clientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PolizaCliente>> post(PolizaCliente polizaCliente)
        {
            try
            {
                _repository.Create(polizaCliente);
            }
            catch (DbUpdateException)
            {
                if (dataExists(polizaCliente.IdCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = polizaCliente.IdCliente }, polizaCliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PolizaCliente>> Delete(int id)
        {
            var polizas = _repository.Find(id);
            if (polizas == null)
            {
                return NotFound();
            }

            _repository.Delete(polizas);

            return polizas;
        }

        private bool dataExists(int id)
        {
            return _repository.Find(id) != null;
        }
    }
}
