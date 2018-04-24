using SportsBet.Data.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Data.Repositories
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        T GetById(object id);
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
