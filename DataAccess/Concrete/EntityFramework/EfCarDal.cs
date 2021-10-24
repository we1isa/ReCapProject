using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
   public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                //referansı yakala - tanımla - save
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return context.Set<Brand>().Where(p=>p.BrandId == brandId).ToList();
            }
        }

        public List<Color> GetCarsByColorId(int colorId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return context.Set<Color>().Where(p=> p.ColorId== colorId).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
