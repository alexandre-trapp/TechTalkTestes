using Npgsql;
using System;
using Microsoft.Extensions.DependencyInjection;
using TechTalkTestes.Domain.Venda.Repositories;

namespace TechTalkTestes.Infra.Database.Postgres
{
    public static class DatabaseServices
    {
        public static NpgsqlConnection OpenConnection()
        {
            var connectionString = PostgreConfiguration.GetConnectionString(
                                        serverName: Environment.GetEnvironmentVariable("POSTGRES_SERVERNAME"),
                                        database: Environment.GetEnvironmentVariable("POSTGRES_DATABASE"),
                                        userId: Environment.GetEnvironmentVariable("POSTGRES_USERID"),
                                        password: Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

            var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            return conn;
        }

        public static void AddServicePostgre(IServiceCollection serviceProvider, NpgsqlConnection conn)
        {
            serviceProvider.AddSingleton(conn);
            serviceProvider.AddSingleton<IVendaCervejaRepository, VendaCervejaRepository>();
        }
    }
}
