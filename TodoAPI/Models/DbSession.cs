using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using Npgsql;

namespace TodoApi.Models
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbSession(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("TodoApp"));

            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
