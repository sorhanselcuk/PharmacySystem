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
    public class AutomatStockInformationManager : IAutomatStockInformationService
    {
        private IAutomatStockInformationDal _automatStockInformationDal;

        public AutomatStockInformationManager(IAutomatStockInformationDal automatStockInformationDal)
        {
            _automatStockInformationDal = automatStockInformationDal;
        }

        public IDataResult<AutomatStockInformation> GetById(int automatId)
        {
            var data = _automatStockInformationDal.Get(a => a.AutomatId == automatId);
            if (data is null)
                return new ErrorDataResult<AutomatStockInformation>();
            return new SuccessDataResult<AutomatStockInformation>(data);
        }
    }
}
