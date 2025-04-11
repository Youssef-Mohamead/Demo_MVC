using System.Linq.Expressions;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        //CRUD OPerations
        // Get Id
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);
        //Get All
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Set<TEntity>().Where(E => E.ISDeleted != true).ToList();
            else
                return _dbContext.Set<TEntity>().Where(E => E.ISDeleted != true).AsNoTracking().ToList();

        }
        // Insert
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
        // Delete
        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> Selector)
        {
         return _dbContext.Set<TEntity>()
                          .Where(e => e.ISDeleted != true)
                          .Select(Selector)
                          .ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> Predicate)
        {
            return _dbContext.Set<TEntity>()
                         .Where(Predicate)
                         .ToList();
        }
    }
}
