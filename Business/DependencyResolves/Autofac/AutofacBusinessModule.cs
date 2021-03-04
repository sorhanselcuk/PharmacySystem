using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ManagerLoads(builder);
            EntityFrameworkLoads(builder);
        }

        private void EntityFrameworkLoads(ContainerBuilder builder)
        {
            builder.RegisterType<EfSupplierDal>().As<ISupplierDal>().SingleInstance();
            builder.RegisterType<EfDrugDal>().As<IDrugDal>().SingleInstance();
        }

        private void ManagerLoads(ContainerBuilder builder)
        {
            builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
            builder.RegisterType<DrugManager>().As<IDrugService>().SingleInstance();
        }
    }
}
