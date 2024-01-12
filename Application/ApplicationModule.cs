using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using System.Reflection;

namespace Application
{
	public class ApplicationModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterMediatR(MediatRConfigurationBuilder.Create(Assembly.GetExecutingAssembly()).Build());

			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.AsClosedTypesOf(typeof(IRequestHandler<,>))
				.InstancePerLifetimeScope();

		}
	}
}
