using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
   public interface ICarService
    {
        List<Car> GetAll();
        
    }
}
