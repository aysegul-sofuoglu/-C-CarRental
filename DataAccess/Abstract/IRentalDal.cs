using Core.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityPepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null);
    }
}
