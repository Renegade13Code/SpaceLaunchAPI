using Microsoft.EntityFrameworkCore;
using SpaceLaunchAPI.Data;

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
