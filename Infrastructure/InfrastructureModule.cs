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
            #region Services
            
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<RecipeService>().As<IRecipeService>().InstancePerLifetimeScope();

            #endregion

            #region Repositories

            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RecipeRepository>().As<IRecipeRepository>().InstancePerLifetimeScope();

            #endregion
        }
    }
}