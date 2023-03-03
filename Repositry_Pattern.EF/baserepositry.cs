using Repositry_Pattern.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Repositry_Pattern.core.consts;


namespace Repositry_Pattern.EF
{
    public class baserepositry<T> : Ibaserepositry<T>where T:class
    {
        protected Applicationdbcontext _context;

        public baserepositry(Applicationdbcontext context)
        {
            _context = context;
        }

        public T Find(Expression<Func<T, bool>> match ,string[] includes= null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(match);




        }

        public IEnumerable<T> Findall(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(match).ToList();

        }
        public IEnumerable<T> Findall(Expression<Func<T, bool>> match, int take, int skip)
        {
            return _context.Set<T>().Where(match).Skip(skip).Take(take).ToList();

        }

        public IEnumerable<T> Findall(Expression<Func<T, bool>> match, int? take, int? skip,
            Expression<Func<T, object>> orderby = null, string orderdbydirection=orderdby.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(match);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderby != null)
            {
                if (orderdbydirection == orderdby.Ascending)
                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);
            }

            return query.ToList();
        }

        public IEnumerable<T> getall()  => _context.Set<T>().ToList();
        

        public T getbyid(int id)   => _context.Set<T>().Find(id);

        public async Task<T> getbyidasync(int id) => await _context.Set<T>().FindAsync(id);

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

       

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

    }

}
