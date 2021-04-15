using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadBase
    {
        protected readonly DbContext Contexto;
        public Repositorio(DbContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(TEntity entidad, string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
