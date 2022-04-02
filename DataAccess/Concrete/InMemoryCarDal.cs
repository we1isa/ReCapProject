using Core.DataAccess;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id=1, BrandId=1, ColorId=0,ModelYear=2001 ,DailyPrice=250, Description="Volvo" } ,
                new Car {Id=2, BrandId=2, ColorId=1,ModelYear=2010 ,DailyPrice=350, Description="Hyundai"},
                new Car {Id=3, BrandId=2, ColorId=2,ModelYear=2011 ,DailyPrice=400, Description="Hyundai"},
                new Car {Id=4, BrandId=3, ColorId=1,ModelYear=2012 ,DailyPrice=450, Description="Opel"},
                new Car {Id=5, BrandId=4, ColorId=3,ModelYear=2020 ,DailyPrice=1000, Description="Mercedes"},
                new Car {Id=6, BrandId=4, ColorId=0,ModelYear=2021 ,DailyPrice=1500, Description="Mercedes"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(car);
            
        }

        

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int ıd)
        {
            return _cars.Where(c=> c.Id== ıd).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.Id==car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        List<Car> IEntityRepository<Car>.GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        List<Car> IEntityRepository<Car>.GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
