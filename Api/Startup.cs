using Api.Middlewares;
using Application;
using Autofac;
using Infrastructure;

public class Startup
{
    public IConfiguration Configuration { get; }

    // Constructor that accepts an IConfiguration object to access settings
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Register services here
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public virtual void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new ApplicationModule());
        builder.RegisterModule(new InfrastructureModule());
    }

    // Configure the middleware pipeline here
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        app.UseSwagger(); // Generate Swagger JSON endpoint
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        }); // Swagger UI to browse the API


        app.UseHttpsRedirection();
        app.UseRouting();

        // Enable the use of controllers in the middleware
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
