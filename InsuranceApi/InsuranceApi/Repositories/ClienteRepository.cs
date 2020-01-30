using InsuranceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Repositories
{
    public class ClienteRepository: RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(masterContext masterContext) : base(masterContext)
        {

        }
    }
}
