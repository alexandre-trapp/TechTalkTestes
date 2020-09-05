using System;
using TechTalkTestes.Domain.Venda.Services;
using TechTalkTestes.Infra.Database.Postgres;
using TechTalkTestes.Domain.Venda.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace TechTalkTestes
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendaRepository = ConfigureDatabaseService();

            new ProgramaVendaCerveja(vendaRepository).EfetuarVendaCerveja();
        }

        private static IVendaCervejaRepository ConfigureDatabaseService()
        {
            Console.WriteLine("Inicializando a aplicação...");

            var conn = DatabaseServices.OpenConnection();

            var serviceCollection = new ServiceCollection();
            DatabaseServices.AddServicePostgre(serviceCollection, conn);

            return serviceCollection.BuildServiceProvider()
                .GetService<IVendaCervejaRepository>();
        }
    }
}
