using TechTalkTestes.Domain.Venda.Entities;
using TechTalkTestes.Domain.Venda.Services;
using TechTalkTestes.Infra.Database.Postgres;
using Microsoft.Extensions.DependencyInjection;
using TechTalkTestes.Domain.Venda.Repositories;
using System;

namespace TechTalkTestes
{
    class Program
    {
        private static IVendaCervejaRepository _vendaRepository;

        static void Main(string[] args)
        {
            ConfigureInfraServices();

            ProgramaVendaCerveja();
        }

        private static void ConfigureInfraServices()
        {
            Console.WriteLine("Inicializando a aplicação...");

            var serviceCollection = new ServiceCollection();
            DatabaseServices.AddServicePostgre(serviceCollection);

            _vendaRepository = serviceCollection.BuildServiceProvider()
                .GetService<IVendaCervejaRepository>();
        }

        private static void ProgramaVendaCerveja()
        {
            VendaCervejaComum vendaBrahma = VenderBrahma();
            VendaCervejaPremium vendaStella = VenderStella();

            ExcluirVendasAntigas();

            CadastrarVendaNaBaseDeDados(vendaBrahma);
            CadastrarVendaNaBaseDeDados(vendaStella);

            new ListarVendas(_vendaRepository)
                .ListarVendasDaBaseDeDados();
        }

        private static void ExcluirVendasAntigas()
        {
            _vendaRepository.ExcluirTodasAsVendas();
        }

        private static VendaCervejaComum VenderBrahma()
        {
            var brahma = new Cerveja(marca: "brahma", valorUnitario: 4.00m);

            var vendaCerveja = new VendaCervejaComum();
            vendaCerveja.VenderCerveja(cerveja: brahma, quantidade: 10);
            return vendaCerveja;
        }

        private static VendaCervejaPremium VenderStella()
        {
            var stella = new Cerveja(marca: "stella artois", valorUnitario: 6.00m, cervejaPremium: true);

            var vendaCerveja = new VendaCervejaPremium();
            vendaCerveja.VenderCerveja(cerveja: stella, quantidade: 5);

            return vendaCerveja;
        }

        private static void CadastrarVendaNaBaseDeDados(VendaCerveja vendaCerveja)
        {
            _vendaRepository.CadastrarVenda(vendaCerveja);
        }
    }
}
