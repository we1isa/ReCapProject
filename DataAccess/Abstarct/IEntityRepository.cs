using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
   public interface IEntityRepository<T> where T : class , IEntity,new()
    {
        List<T> GetAll(Expression<Func<T , bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> filter);
        List<Brand> GetCarsByBrandId(int brandId);
        List<Color> GetCarsByColorId(int colorId);

    }
}
