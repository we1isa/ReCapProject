using Business.Concrete;
using Business.Constants;
using DataAccess;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BrandGetAllTest();
            //ColorGetAllTest();
            //CarDetailsTest();
            //CarAddTest();

        }

        private static void CarAddTest()
        {
            Car car = new Car();
            car.BrandId = 12;
            car.ColorId = 12;
            car.DailyPrice = 250;
            car.Description = "Yeni araç";
            car.ModelYear = 2022;
            car.Id = 12;
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in colorManager.GetAll().Data)
                {
                    Console.WriteLine(color.ColorId + " - " + color.ColorName);
                }
            }else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success==true)
            {
                foreach (var brands in brandManager.GetAll().Data)
                {
                    Console.WriteLine("{0} - {1}", brands.BrandId, brands.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + "-" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
