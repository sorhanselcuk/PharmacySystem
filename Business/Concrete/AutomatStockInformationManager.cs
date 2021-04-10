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
    public class AutomatStockInformationManager : IAutomatStockInformationService
    {
        private IAutomatStockInformationDal _automatStockInformationDal;

        public AutomatStockInformationManager(IAutomatStockInformationDal automatStockInformationDal)
        {
            _automatStockInformationDal = automatStockInformationDal;
        }

        [CacheAspect(60)]
        public IDataResult<List<AutomatStockInformation>> GetByDrugId(int drugId)
        {
            var data = _automatStockInformationDal.GetAll(a => a.DrugId == drugId);
            if (data.Count == 0)
                return new ErrorDataResult<List<AutomatStockInformation>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<AutomatStockInformation>>(data, Message.Success);
        }

        public IDataResult<List<AutomatStockInformation>> GetById(int automatId)
        {
            var data = _automatStockInformationDal.GetAll(a => a.AutomatId == automatId);
            if (data.Count == 0)
                return new ErrorDataResult<List<AutomatStockInformation>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<AutomatStockInformation>>(data, Message.Success);
        }
    }
}
