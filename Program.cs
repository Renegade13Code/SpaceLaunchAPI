using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;
using SpaceLaunchAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register the dbContext as a dependency for dependency injection
builder.Services.AddDbContext<SpaceLaunchDbContext>(options =>
{
    // UseSqlServer takes the connection string to the database as its argument. Here the connection string is grabed from the appsettings.json file via the builder object.
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpaceLaunch"));
});

//Register repositories for dependency injection
builder.Services.AddScoped<IRocketRepository , RocketRepository>();
builder.Services.AddScoped<ILaunchpadRepository , LaunchpadRepository>();
builder.Services.AddScoped<IPayloadRepository , PayloadRepository>();
builder.Services.AddScoped<ILaunchRepository , LaunchRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
