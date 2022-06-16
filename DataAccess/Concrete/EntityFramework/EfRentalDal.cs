using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from r in context.Rental
                             join c in context.Car on r.CarId equals c.Id
                             join b in context.Brand on c.BrandId equals b.Id
                             join u in context.User on r.CustomerId equals u.UserId
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 FirstName = u.UserFirstName,
                                 LastName = u.UserLastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
