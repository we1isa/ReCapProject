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
            //CustomerAddTest();
            //CustomerGetByIdTest();
            //CustomerUpdateTest();
            //RentalAddTest();

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental());
            if (result.Success == true)
            {                                                                                             //?
                rentalManager.Add(new Rental { Id = 10, CarId = 10, RentDate = new DateTime(2022, 04, 04), ReturnDate = null, CustomerId = 10 });
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerUpdateTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Update(new Customer { CustomerId = 1, CompanyName = "Güncellenmiş şirket", UserId = 4 });
        }

        private static void CustomerGetByIdTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetById(3).Data)
            {
                Console.WriteLine("{0} ~ {1}", customer.UserId, customer.CompanyName);
            }
        }

        private static void CarAddTest()
        {
            Car car = new Car();
            car.BrandId = 10;
            car.ColorId = 10;
            car.DailyPrice = 250;
            car.Description = "Yeni araç";
            car.ModelYear = 2022;
            car.Id = 10;
            CarManager carManager = new CarManager(new EfCarDal());
            
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

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CustomerId =4 , CompanyName = "Yeni Müşteri şirketi", UserId = 4 });
        }

        
    }
    
}
