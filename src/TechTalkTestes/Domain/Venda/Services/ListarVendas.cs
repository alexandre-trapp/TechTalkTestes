using System;
using TechTalkTestes.Domain.Venda.Repositories;

namespace TechTalkTestes.Domain.Venda.Services
{
    public class ListarVendas
    {
        private readonly IVendaCervejaRepository _vendaCervejaRepo;

        public ListarVendas(IVendaCervejaRepository vendaCervejaRepo)
        {
            _vendaCervejaRepo = vendaCervejaRepo;
        }

        public void ListarVendasDaBaseDeDados()
        {
            var listaVendas = _vendaCervejaRepo.ListarTodasAsVendas();

            Console.WriteLine(string.Empty);
            Console.WriteLine("---------------------------.");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Lista das vendas realizadas:");
            Console.WriteLine(string.Empty);

            Console.WriteLine("marca - valor unitário - quantidade - valor total da venda");
            Console.WriteLine(listaVendas);
        }
    }
}
