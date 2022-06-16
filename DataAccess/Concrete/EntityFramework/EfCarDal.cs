using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from c in context.Car
                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             select new CarDetailDto()
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = clr.ColorName
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

       
    }
}
