﻿using EntityModel;
using Microsoft.EntityFrameworkCore;

namespace EntityModel
{
    public interface IWeatherContext
    {
        DbSet<WeatherForecastEntity> WeatherForecast { get; set; }
        DbSet<WeatherSummary> WeatherSummary { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}