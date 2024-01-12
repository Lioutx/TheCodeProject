using Application.Common.Interfaces;
using Autofac;
using Infrastructure.Interfaces;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Services;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
        }
    }
}