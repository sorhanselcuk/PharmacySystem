using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AutomatManager : IAutomatService
    {
        private IAutomatDal _automatDal;

        public AutomatManager(IAutomatDal automatDal)
        {
            _automatDal = automatDal;
        }

        public IResult Add(Automat automat)
        {
            _automatDal.Add(automat);
            return new SuccessResult("Automat was successfully added!");
        }

        public IResult Delete(Automat automat)
        {
            _automatDal.Delete(automat);
            return new SuccessResult("Automat was successfully deleted!");
        }

        public IDataResult<List<Automat>> GetAll()
        {
            var data = _automatDal.GetAll();
            if (data is null)
                return new ErrorDataResult<List<Automat>>();
            return new SuccessDataResult<List<Automat>>(data);
        }

        public IDataResult<Automat> GetById(int id)
        {
            var data = _automatDal.Get(a=>a.Id==id);
            if (data is null)
                return new ErrorDataResult<Automat>();
            return new SuccessDataResult<Automat>(data);
        }

        public IDataResult<List<Automat>> GetByTownId(int townId)
        {
            var data = _automatDal.GetAll(t=>t.TownId==townId);
            if (data is null)
                return new ErrorDataResult<List<Automat>>();
            return new SuccessDataResult<List<Automat>>(data);
        }

        public IResult Update(Automat automat)
        {
            _automatDal.Update(automat);
            return new SuccessResult("Automat was successfully Updated!");
        }
    }
}
