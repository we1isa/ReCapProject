using Business.Abstract;
using DataAccess.Abstarct;
using Entities.Concrete;
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
        public List<Brand> GetAll()
        {
            return _branDal.GetAll();
        }
    }
}
