using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ListOfColors);
            }
        }

        public IDataResult<Color> GetById(int colorId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messages.ColorDetail);
            }
        }

        public IResult Update(Color color)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
        }
    }
}
