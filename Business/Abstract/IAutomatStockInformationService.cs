﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAutomatStockInformationService
    {
        IDataResult<List<AutomatStockInformation>> GetById(int automatId);
        IDataResult<AutomatStockInformation> GetByDrugId(int drugId);
    }
}
