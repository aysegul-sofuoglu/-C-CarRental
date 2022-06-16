using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine(car.Id + " / " + car.BrandName);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                System.Console.WriteLine(brand.BrandName);
            }

        }

    }
}
