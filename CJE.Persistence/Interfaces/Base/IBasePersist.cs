using CJE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Persistence.Interfaces.Base
{
    public interface IBasePersist<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(T[] entity);
        Task<bool> SaveChangesAsync();
    }
}
