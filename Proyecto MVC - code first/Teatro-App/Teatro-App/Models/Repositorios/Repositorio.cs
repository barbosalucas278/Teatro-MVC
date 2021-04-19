using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadBase
    {
        protected readonly DbContext _Contexto;
        public Repositorio(DbContext contexto)
        {
            _Contexto = contexto;
        }
        /// <summary>
        /// Trae todos los elementos TEntity que cumplan con que la MarcaUso y Activo son true asincrónicamente.
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAll()
        {
            return await _Contexto.Set<TEntity>().Where(x => x.Activo && x.MarcaUso).ToListAsync();
        }
        /// <summary>
        /// Si el usuario que modifica no es nulo o vacio agrega un nuevo elemento del tipo TEntity al contexto.
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="usuario"></param>
        public void Add(TEntity entidad, string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                throw new Exception("El usuario no puede ser nulo");
            }
            entidad.UsuarioModificacion = usuario;
            _Contexto.Set<TEntity>().Add(entidad);
        }
        /// <summary>
        /// Busca una entidad mediante un predicado en el Where
        /// </summary>
        /// <param name="predicate">Criterio de bsuqueda</param>
        /// <returns></returns>
        public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Contexto.Set<TEntity>()
                .Where(predicate)
                .Where(t => t.Activo && t.MarcaUso)
                .ToListAsync();
        }
        /// <summary>
        /// Da de baja una entidad del contexto.
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="usuario"></param>
        public void Remove(TEntity entidad, string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                throw new Exception("El usuario no puede ser nulo");
            }
            var resultadoBusqueda = _Contexto.Set<TEntity>().FindAsync(entidad).Result;
            if (resultadoBusqueda != null)
            {
                resultadoBusqueda.UsuarioModificacion = usuario;
                resultadoBusqueda.Activo = false;
                resultadoBusqueda.FechaBaja = DateTime.Now;
            }

        }
    }
}
