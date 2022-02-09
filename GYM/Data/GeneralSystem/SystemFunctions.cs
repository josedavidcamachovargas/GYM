using GYM.Data.GeneralSystem.IGeneralSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace GYM.Data.GeneralSystem
{

        public class SystemFunctions<T> : ISystemFunctions<T> where T : class
        {
            private readonly ApplicationDbContext _db;
            internal DbSet<T> dbSet;

            public SystemFunctions(ApplicationDbContext db)
            {
                _db = db;
                this.dbSet = _db.Set<T>();
            }

            public void Add(T entity)
            {
                dbSet.Add(entity);
            }

            public async Task<T> Get(int id)
            {
                return await dbSet.FindAsync(id);
            }

            public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    var props = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in props)
                    {
                        query.Include(p);
                    }
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }

                return await query.ToListAsync();
            }

            public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    var props = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in props)
                    {
                        query.Include(p);
                    }
                }

                return await query.FirstOrDefaultAsync();
            }

            public void Remove(int id)
            {
                T entity = dbSet.Find(id);
                Remove(entity);
            }

            public void Remove(T entity)
            {
                dbSet.Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entity)
            {
                dbSet.RemoveRange(entity);
            }
        }
}
