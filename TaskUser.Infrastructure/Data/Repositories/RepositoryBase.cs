using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Base;
using TaskUser.Domain.Repositories;

namespace TaskUser.Infrastructure.Data.Repositories
{

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private EFDbContext _ctx;
        private DbSet<TEntity> _dbSet;
        public RepositoryBase(EFDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }


        public List<TEntity> GetAll()
        {
            return _dbSet.OrderBy(x => x.Id).ToList();
        }

        public TEntity GetById(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public void Remove(Guid Id)
        {
            var data = _dbSet.Find(Id);
            _ctx.Remove(data);
            _ctx.SaveChanges();
        }

        public TEntity Create(TEntity obj)
        {
            obj.Id = Guid.NewGuid();
            var result = _dbSet.Add(obj);
            _ctx.SaveChanges();
            return obj;
        }


        public TEntity Update(TEntity obj)
        {
            var entity = _dbSet.Find(obj.Id);
            var entry = _ctx.Entry(entity);
            entry.CurrentValues.SetValues(obj);
            _ctx.SaveChanges();
            return obj;
        }



        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
                query = orderBy(query);
            return query;
        }

    }
}

