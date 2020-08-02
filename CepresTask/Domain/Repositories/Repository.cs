using CepresTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CepresTask.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private CepresDBContext _context;

        public Repository(CepresDBContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public bool SaveChanges()
        {
            
                return (_context.SaveChanges()>0);
            
        }

        public TEntity Get(Guid Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetData(GetListRequest request)
        {           

            IEnumerable<TEntity> result = _context.Set<TEntity>();            
            result = Sort(result,request.Sort, request.SortDirection)
                .Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize); ;
            return result;


        }
       
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveAll()
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>());
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        protected IEnumerable<TEntity> Sort(IEnumerable<TEntity> source, string sortBy, string sortDirection)
        {
            if (string.IsNullOrEmpty(sortBy))
                return source;
            var param = Expression.Parameter(typeof(TEntity), "item");

            var sortExpression = Expression.Lambda<Func<TEntity, object>>
                (Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);

            switch (sortDirection.ToLower())
            {
                case "asc":
                    return source.AsQueryable<TEntity>().OrderBy<TEntity, object>(sortExpression);
                default:
                    return source.AsQueryable<TEntity>().OrderByDescending<TEntity, object>(sortExpression);

            }
        }

        public long GetCount()
        {
            return _context.Set<TEntity>().Count();
        }
    }
}
