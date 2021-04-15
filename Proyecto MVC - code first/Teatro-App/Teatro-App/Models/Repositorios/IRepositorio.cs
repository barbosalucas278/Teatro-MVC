using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public interface IRepositorio<TEntity> where TEntity : EntidadBase
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Find(Expression<Func<TEntity,bool>> predicate);
        void Add(TEntity entidad, string usuario);
        void Remove(TEntity entidad, string usuario);
    }
}
