using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AutomatManager : IAutomatService
    {
        private IAutomatDal _automatDal;

        public AutomatManager(IAutomatDal automatDal)
        {
            _automatDal = automatDal;
        }

        //[AuthorizationAspect("IAutomatService.Add,IAutomatService")]
        [CacheRemoveAspect("IAutomatService.Get")]
        public IResult Add(Automat automat)
        {
            _automatDal.Add(automat);
            return new SuccessResult(Message.AutomatSuccessfullyAdded);
        }

        //[AuthorizationAspect("IAutomatService.Delete,IAutomatService")]
        [CacheRemoveAspect("IAutomatService.Get")]
        public IResult Delete(Automat automat)
        {
            _automatDal.Delete(automat);
            return new SuccessResult(Message.AutomatSuccessfullyDeleted);
        }

        [CacheAspect(60)]
        public IDataResult<List<Automat>> GetAll()
        {
            var data = _automatDal.GetAll();
            if (data.Count == 0)
                return new ErrorDataResult<List<Automat>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<Automat>>(data, Message.Success);
        }

        public IDataResult<Automat> GetById(int id)
        {
            var data = _automatDal.Get(a => a.Id == id);
            if (data is null)
                return new ErrorDataResult<Automat>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<Automat>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Automat>> GetByTownId(int townId)
        {
            var data = _automatDal.GetAll(t => t.TownId == townId);
            if (data.Count == 0)
                return new ErrorDataResult<List<Automat>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<Automat>>(data, Message.Success);
        }

        //[AuthorizationAspect("IAutomatService.Add")]
        [CacheRemoveAspect("IAutomatService.Update,IAutomatService")]
        public IResult Update(Automat automat)
        {
            _automatDal.Update(automat);
            return new SuccessResult(Message.Success);
        }
    }
}
