using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class WeatherContext : DbContext, IWeatherContext
    {
        public DbSet<WeatherForecastEntity> WeatherForecast { get; set;}
        public DbSet<WeatherSummary> WeatherSummary { get; set; }
        public DbSet<User> Users { get; set; }

        public WeatherContext() { }

        public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:server130122022.database.windows.net,1433;Initial Catalog=databaseTest;Persist Security Info=False;User ID=userAdmin;Password=passwordAdmin18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }




    }
}
