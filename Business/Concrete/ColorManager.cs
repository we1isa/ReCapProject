using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstarct;
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
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 14)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
            }
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(b=>b.ColorId==id), Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
