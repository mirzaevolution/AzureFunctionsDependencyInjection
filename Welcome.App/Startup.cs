using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Welcome.ServiceAbstracts;
using Welcome.Services;
using Welcome.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.Diagnostics;

[assembly: FunctionsStartup(typeof(Welcome.App.Startup))]
namespace Welcome.App
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;
            builder.Services.AddDbContext<WelcomeDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IConfigMapService, ConfigMapService>();
            builder.Services.AddAutoMapper(typeof(Startup));

        }
    }
}
