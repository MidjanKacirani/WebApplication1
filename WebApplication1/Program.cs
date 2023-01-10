using EntityModel;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWeatherContext, WeatherContext>();
builder.Services.AddDbContext<WeatherContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDatabase"), x => x.MigrationsAssembly("EntityModel")));

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
