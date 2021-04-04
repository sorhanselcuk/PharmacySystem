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
    public class TownManager : ITownService
    {
        private ITownDal _townDal;

        public TownManager(ITownDal townDal)
        {
            _townDal = townDal;
        }

        public IDataResult<List<Town>> GetAll()
        {
            var data = _townDal.GetAll();
            if (data.Count == 0)
                return new ErrorDataResult<List<Town>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<Town>>(data, Message.Success);
        }

        public IDataResult<List<Town>> GetAllByCityId(int cityId)
        {
            var data = _townDal.GetAll(t => t.CityId == cityId);
            if (data.Count == 0)
                return new ErrorDataResult<List<Town>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<Town>>(data, Message.Success);
        }

        public IDataResult<Town> GetTownById(int id)
        {
            var data = _townDal.Get(t => t.Id == id);
            if (data is null)
                return new ErrorDataResult<Town>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<Town>(data, Message.Success);
        }
    }
}
