using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Formulario.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        TEntity Create(TEntity model);

        List<TEntity> Create(List<TEntity> models);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> where, ProjectionDefinition<TEntity> includes);

        bool Update(Expression<Func<TEntity, bool>> predicate, TEntity modelReplacement);

        bool Remove(Expression<Func<TEntity, bool>> predicate);

        bool Remove(object id);

        #region 'Metodos Assíncronos'

        #region 'Métodos Criar/Atualizar/Excluir/Salvar'

        Task<TEntity> CreateAsync(TEntity model);

        Task<bool> UpdateAsync(TEntity model);

        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where);

        Task<bool> DeleteAsync(TEntity model);

        Task<bool> DeleteAsync(params object[] Keys);

        Task<int> SaveAsync();

        #endregion

        #region 'Métodos de Busca'

        Task<TEntity> GetAsync(params object[] Keys);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);

        #endregion

        #endregion*/
    }
}
