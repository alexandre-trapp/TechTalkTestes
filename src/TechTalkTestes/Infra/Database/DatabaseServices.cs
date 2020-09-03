using Npgsql;
using Microsoft.Extensions.DependencyInjection;
using TechTalkTestes.Domain.Venda.Repositories;

namespace TechTalkTestes.Infra.Database.Postgres
{
    public static class DatabaseServices
    {
        public static void AddServicePostgre(IServiceCollection serviceProvider)
        {
            var connection = OpenConnection();
            serviceProvider.AddSingleton(connection);

            serviceProvider.AddSingleton<IVendaCervejaRepository, VendaCervejaRepository>();
        }

        private static NpgsqlConnection OpenConnection()
        {
            var connectionString = PostgreConfiguration.ConnectionString;

            var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            return conn;
        }
    }
}
