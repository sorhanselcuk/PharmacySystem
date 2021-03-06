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

        public IDataResult<AutomatStockInformation> GetByDrugId(int drugId)
        {
            var data = _automatStockInformationDal.GetAll(a => a.DrugId == drugId);
            if (data is null)
                return new ErrorDataResult<AutomatStockInformation>();
            return new SuccessDataResult<AutomatStockInformation>();
        }

        public IDataResult<List<AutomatStockInformation>> GetById(int automatId)
        {
            var data = _automatStockInformationDal.GetAll(a => a.AutomatId == automatId);
            if (data is null)
                return new ErrorDataResult<List<AutomatStockInformation>>();
            return new SuccessDataResult<List<AutomatStockInformation>>(data);
        }
    }
}
