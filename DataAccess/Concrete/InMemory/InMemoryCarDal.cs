using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> { 
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=60000, ModelYear=2010, Description="Audi"},
                new Car{CarId=2, BrandId=1, ColorId=3, DailyPrice=50000, ModelYear=2010, Description="BMW"},
                new Car{CarId=3, BrandId=2, ColorId=5, DailyPrice=600000, ModelYear=2010, Description="Ford"},
                new Car{CarId=4, BrandId=2, ColorId=2, DailyPrice=800000, ModelYear=2010, Description="Volkswagen"},
                new Car{CarId=5, BrandId=3, ColorId=1, DailyPrice=6000, ModelYear=2010, Description="Masserati"}
                };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(deletedCar);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car updatedCar = _car.SingleOrDefault(c => c.CarId == car.CarId);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
        }
    }
}
