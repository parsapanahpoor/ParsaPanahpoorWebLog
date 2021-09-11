using DataContext.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Design_Pattern.GenericRepository
{
    public class GenericRepsotory<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ParsaPanahpoorDbContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepsotory(ParsaPanahpoorDbContext _context)
        {
            context = _context;
            this.dbSet = _context.Set<TEntity>();

        }


        public void Delete(object Id)
        {
            var entity = GetById(Id);

            if (entity == null)
                throw new ArgumentException("on entity");

            dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = dbSet.Where(where).AsEnumerable();

            foreach (var item in objects)
            {
                dbSet.Remove(item);
            }

        }


        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public TEntity GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }


        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }

        public TEntity GetSingleOrDefualt()
        {
            return dbSet.SingleOrDefault();
        }
    }
}
