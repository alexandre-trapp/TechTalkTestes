using Npgsql;
using TechTalkTestes.Infra.Database.Postgres;
using Microsoft.Extensions.DependencyInjection;
using TechTalkTestes.Domain.Venda.Repositories;

namespace TechTalkTestes.Integration.Tests
{
    public static class Repositories
    {
        public static IVendaCervejaRepository _vendaCervejaRepository;

        public static void CreateRepositoriesTest(NpgsqlConnection conn)
        {
            var serviceCollection = new ServiceCollection();
            DatabaseServices.AddServicePostgre(serviceCollection, conn);

            _vendaCervejaRepository = serviceCollection.BuildServiceProvider()
                .GetService<IVendaCervejaRepository>();
        }
    }
}
