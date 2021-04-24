using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ManagerLoads(builder);
            EntityFrameworkLoads(builder);
            UtilitiesLoads(builder);

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

        private void UtilitiesLoads(ContainerBuilder builder)
        {
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }

        private void EntityFrameworkLoads(ContainerBuilder builder)
        {
            builder.RegisterType<EfSupplierDal>().As<ISupplierDal>().SingleInstance();
            builder.RegisterType<EfDrugDal>().As<IDrugDal>().SingleInstance();
            builder.RegisterType<EfAutomatDal>().As<IAutomatDal>().SingleInstance();
            builder.RegisterType<EfAutomatStockInformationDal>().As<IAutomatStockInformationDal>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<EfTownDal>().As<ITownDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();
            builder.RegisterType<EfSupplierUserDal>().As<ISupplierUserDal>().SingleInstance();
        }

        private void ManagerLoads(ContainerBuilder builder)
        {
            builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
            builder.RegisterType<DrugManager>().As<IDrugService>().SingleInstance();
            builder.RegisterType<AutomatManager>().As<IAutomatService>().SingleInstance();
            builder.RegisterType<AutomatStockInformationManager>().As<IAutomatStockInformationService>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<TownManager>().As<ITownService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<SupplierUserManager>().As<ISupplierUserService>().SingleInstance();
        }
    }
}
