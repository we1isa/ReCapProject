using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _branDal;
        public BrandManager(IBrandDal brandDal)
        {
            _branDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            else
            {
                _branDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IResult Delete(Brand brand)
        {
            _branDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour ==14)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll(c => c.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            _branDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
