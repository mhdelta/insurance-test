using InsuranceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Repositories
{
    public class PolizaClienteRepository : RepositoryBase<PolizaCliente>, IPolizaClienteRepository
    {
        public PolizaClienteRepository(masterContext masterContext) : base(masterContext)
        {

        }
    }
}
