using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        T Find(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
