using System;
using System.Configuration;
using ImageServiceAPI.Services;

namespace ImageServiceAPI.Models
{
    public class DbConnection
    {
        public DbConnection(WebApplicationBuilder builder)
        {

            if (connectionString == null)
            {
                throw new InvalidOperationException("Connection String has not been initialized");
            }
            else if (connectionString.ToLower().Contains("postgres"))
            {
                builder.Services.AddScoped<IImageRepository, SqlImageRepository>();
            }
            else if (connectionString.ToLower().Contains("mongodb"))
            {
                builder.Services.AddScoped<IImageRepository, MongoImageRepository>();
            }
            else throw new InvalidOperationException("Connection String does not contain a database specification");
        }
        public string? connectionString = Environment.GetEnvironmentVariable("connectionstring");



    }
}
