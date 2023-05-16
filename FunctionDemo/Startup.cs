
using Data.Repository;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(FunctionDemo.Startup))]

namespace FunctionDemo
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=.;Initial Catalog=HarmonyAdmin;MultipleActiveResultSets=true;User ID=sa;Password=Vn@2022@;TrustServerCertificate=True";
            }
            builder.Services.AddDbContext<dbDataContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}