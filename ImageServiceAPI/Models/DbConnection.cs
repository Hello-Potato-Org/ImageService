using System;
using System.Configuration;

namespace ImageServiceAPI.Models
{
    public class DbConnection
    {
        public DbConnection(){}
        public string? connectionString = Environment.GetEnvironmentVariable("connectionstring");

    }
}
