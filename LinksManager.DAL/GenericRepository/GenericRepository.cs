using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using LinksManager.DAL.Context;

namespace LinksManager.DAL.GenericRepository
{
    public class GenericRepository<TEntity> where TEntity:class 
    {
        private readonly LinksManagerContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(LinksManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #region Methods
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = _dbSet;
            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.AddOrUpdate(entityToUpdate);
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return _dbSet.Where(where).ToList();
        }


        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return _dbSet.Where(where).AsQueryable();
        }

        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return _dbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = _dbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<TEntity> GetWithInclude(
            System.Linq.Expressions.Expression<Func<TEntity,
            bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this._dbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public bool Exists(object primaryKey)
        {
            return _dbSet.Find(primaryKey) != null;
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return _dbSet.Single<TEntity>(predicate);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return _dbSet.First<TEntity>(predicate);
        }
        #endregion
    }
}
    

