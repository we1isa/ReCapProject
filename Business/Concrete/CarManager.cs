using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && (car.DailyPrice > 0))
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Geçersiz Car girdisi");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
       
    
    }
}
