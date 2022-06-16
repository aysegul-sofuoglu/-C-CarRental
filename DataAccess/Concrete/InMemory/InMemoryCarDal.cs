using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                 new Car{Id=1,BrandId=1,ColorId=1,ModelYear=1990,DailyPrice=500,Description="SEDAN"},
                new Car{Id=1006,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=500,Description="SPORT"},
                new Car{Id=1007,BrandId=2,ColorId=2,ModelYear=2023,DailyPrice=500,Description="PICKUP"},
                new Car{Id=1008,BrandId=3,ColorId=3,ModelYear=2028,DailyPrice=500,Description="COMPACT"},
                new Car{Id=1009,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=500,Description="HATCHBACK"},

                };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updatedCar = _car.SingleOrDefault(c => c.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
        }
    }
}
