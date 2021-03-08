using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IDataResult<List<City>> GetAll()
        {
            var data = _cityDal.GetAll();
            if (data is null)
                return new ErrorDataResult<List<City>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<City>>(data,Message.Success);
        }

        public IDataResult<City> GetCityById(int id)
        {
            var data = _cityDal.Get(c => c.Id == id);
            if (data is null)
                return new ErrorDataResult<City>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<City>(data,Message.Success);
        }
    }
}
