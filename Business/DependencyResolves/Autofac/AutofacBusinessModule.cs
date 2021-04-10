using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
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
            builder.RegisterType<EfAutomatDal>().As<IAutomatDal>().SingleInstance();
            builder.RegisterType<EfAutomatStockInformationDal>().As<IAutomatStockInformationDal>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<EfTownDal>().As<ITownDal>().SingleInstance();
        }

        private void ManagerLoads(ContainerBuilder builder)
        {
            builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
            builder.RegisterType<DrugManager>().As<IDrugService>().SingleInstance();
            builder.RegisterType<AutomatManager>().As<IAutomatService>().SingleInstance();
            builder.RegisterType<AutomatStockInformationManager>().As<IAutomatStockInformationService>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<TownManager>().As<ITownService>().SingleInstance();
        }
    }
}
