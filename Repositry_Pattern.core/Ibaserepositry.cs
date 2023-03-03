using Repositry_Pattern.core.consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositry_Pattern.core
{
    public interface Ibaserepositry<T> where T : class 
    {

        T getbyid (int id);
        Task <T> getbyidasync(int id);
        IEnumerable<T> getall();
        public T Find(Expression<Func<T, bool>> match,string []includes=null);

        IEnumerable<T>  Findall(Expression<Func<T, bool>> match, string[] includes = null);

        IEnumerable<T> Findall(Expression<Func<T, bool>> match, int take ,int skip );
        IEnumerable<T> Findall(Expression<Func<T, bool>> match, int? take, int? skip,
            Expression<Func<T, object>> orderby = null, String orderdbydirection = orderdby.Ascending);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);


    }
    
    
}
