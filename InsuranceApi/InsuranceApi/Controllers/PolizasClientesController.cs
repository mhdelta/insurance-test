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
        [Authorize]
        public async Task<ActionResult<PolizaCliente>> post(PolizaCliente polizaCliente)
        {
            try
            {
                var poli = _repository.Find(polizaCliente.IdCliente, polizaCliente.IdPoliza);
                if (poli == null)
                {
                    _repository.Create(polizaCliente);
                }
                else {
                    return StatusCode(200, "El cliente ya cuenta con esta poliza");
                }

                return Ok("{}");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<PolizaCliente>> Delete(int idCliente, int idPoliza)
        {
            var poliza = _repository.Find(idCliente, idPoliza);
            if (poliza == null)
            {
                return NotFound();
            }

            _repository.Delete(poliza);

            return Ok("{}");
        }

        private bool dataExists(int id)
        {
            return _repository.Find(id) != null;
        }
    }
}
