using Formulario.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Formulario.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;

        protected IMongoCollection<TEntity> _dbSet => _context.Set<TEntity>();

        public Repository(Context context)
        {
            _context = context;
        }

        public TEntity Create(TEntity model)
        {
            try
            {
                _dbSet.InsertOne(model);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TEntity> Create(List<TEntity> models)
        {
            try
            {
                _dbSet.InsertMany(models);

                return models;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _dbSet.Find(predicate)
                             .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="predicate"></param>
        /// Exemplo de include ****
        /// var _includes = Builders<TEntity>.Projection.Include(p => p.Nome).Include(p => p.Email);</param>
        /// <returns></returns>
        public TEntity Find(Expression<Func<TEntity, bool>> predicate, ProjectionDefinition<TEntity> includes)
        {
            try
            {
                if (includes != null)
                    return _dbSet.Find(predicate).Project<TEntity>(includes).FirstOrDefault();
                else
                    return _dbSet.Find(predicate).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                    return _dbSet.Find(where).ToEnumerable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includes">
        /// Exemplo de include ****
        /// var _includes = Builders<TEntity>.Projection.Include(p => p.Nome).Include(p => p.Email);</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> where, ProjectionDefinition<TEntity> includes)
        {
            try
            {
                if (includes != null)
                    return _dbSet.Find(where).Project<TEntity>(includes).ToEnumerable();
                else
                    return _dbSet.Find(where).ToEnumerable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Expression<Func<TEntity, bool>> predicate, TEntity modelReplacement)
        {
            try
            {
                var _result = _dbSet.ReplaceOne(predicate, modelReplacement);

                return _result.IsAcknowledged;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(object id)
        {
            try
            {
                var _filter = Builders<TEntity>.Filter.Eq(nameof(id), id);
                var _result = _dbSet.DeleteOne(_filter);

                return _result.IsAcknowledged;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var _result = _dbSet.DeleteOne(predicate);

                return _result.IsAcknowledged;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<TEntity> CreateAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(params object[] Keys)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(params object[] Keys)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
