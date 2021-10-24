using Business.Concrete;
using DataAccess;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("{0} - {1}", cars.BrandId , cars.Description);

            }
            
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine("{0} - {1}", brands.BrandId , brands.BrandName);
            }
        }
    }
}
