using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Buidler;
using SpaceLaunchAPI.Builder;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Repository;

namespace SpaceLaunchAPI_v2;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<SpaceLaunchDbContext>(options =>
        {
            // UseSqlServer takes the connection string to the database as its argument. Here the connection string is grabed from the appsettings.json file via the builder object.
            options.UseSqlServer(Configuration.GetConnectionString("SpaceLaunch"));
        });

        services.AddScoped<IRocketRepository, RocketRepository>();
        services.AddScoped<ILaunchpadRepository, LaunchpadRepository>();
        services.AddScoped<ILaunchRepository, LaunchRepository>();
        services.AddScoped<IPayloadRepository, PayloadRepository>();
        services.AddScoped<IBuilderLaunches, LaunchBuilder>();
        services.AddScoped<ICapsuleRepository, CapsuleRepository>();
        services.AddScoped<IAstronautRepository, AstronautRepository>();
        services.AddScoped<IObserverRepository, ObserverRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        app.UseSwagger();
        app.UseSwaggerUI();
 

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}