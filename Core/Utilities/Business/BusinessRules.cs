using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] args)
        {
            IResult response = null;
            foreach (var arg in args)
            {
                if (!arg.Success)
                    response = arg;
            }
            return response;
        }
    }
}
