using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.Notificaciones
{
    public static class Config
    {
        private static IConfiguration Configuration =  new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();


        public static string ConnectionString => Configuration.GetConnectionString("Meetup");



    }
}
