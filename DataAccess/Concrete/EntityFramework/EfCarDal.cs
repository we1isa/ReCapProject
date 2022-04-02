using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join o in context.Colors on c.ColorId equals o.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId=c.Id, CarName = c.Description, ColorName = o.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
