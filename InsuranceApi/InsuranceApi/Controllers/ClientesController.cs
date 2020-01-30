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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClientesController(IClienteRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _repository.FindAll().ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientes(int id)
        {
            var clientes = _repository.Find(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // POST: api/Clientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostClientes(Cliente cliente)
        {
            try
            {
                _repository.Create(cliente);
            }
            catch (DbUpdateException)
            {
                if (ClientesExists(cliente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientes", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteClientes(int id)
        {
            var cliente = _repository.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _repository.Delete(cliente);

            return cliente;
        }

        private bool ClientesExists(int id)
        {
            return _repository.Find(id) != null;
        }
    }
}
