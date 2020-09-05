using TechTalkTestes.Domain.Venda.Entities;
using TechTalkTestes.Domain.Venda.Repositories;

namespace TechTalkTestes.Domain.Venda.Services
{
    public class ProgramaVendaCerveja
    {
        private readonly IVendaCervejaRepository _vendaRepository;
        public decimal ValorTotalDasVendas { get; private set; }

        public ProgramaVendaCerveja(IVendaCervejaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public void EfetuarVendaCerveja()
        {
            VendaCervejaComum vendaBrahma = VenderBrahma();
            VendaCervejaPremium vendaStella = VenderStella();

            ExcluirVendasAntigas();

            CadastrarVendaNaBaseDeDados(vendaBrahma);
            CadastrarVendaNaBaseDeDados(vendaStella);

            SomarValorTotalDasVendas(vendaBrahma, vendaStella);

            new ListarVendas(_vendaRepository)
                .ListarVendasDaBaseDeDados();
        }

        private void ExcluirVendasAntigas()
        {
            _vendaRepository.ExcluirTodasAsVendas();
        }

        private VendaCervejaComum VenderBrahma()
        {
            var brahma = new Cerveja(marca: "brahma", valorUnitario: 4.00m);

            var vendaCerveja = new VendaCervejaComum();
            vendaCerveja.VenderCerveja(cerveja: brahma, quantidade: 10);

            return vendaCerveja;
        }

        private VendaCervejaPremium VenderStella()
        {
            var stella = new Cerveja(marca: "stella artois", valorUnitario: 6.00m, cervejaPremium: true);

            var vendaCerveja = new VendaCervejaPremium();
            vendaCerveja.VenderCerveja(cerveja: stella, quantidade: 5);

            return vendaCerveja;
        }

        private void CadastrarVendaNaBaseDeDados(VendaCerveja vendaCerveja)
        {
            _vendaRepository.CadastrarVenda(vendaCerveja);
        }

        private void SomarValorTotalDasVendas(VendaCervejaComum vendaBrahma, VendaCervejaPremium vendaStella)
        {
            ValorTotalDasVendas = vendaBrahma.ValorTotalDaVenda + vendaStella.ValorTotalDaVenda;
        }
    }
}
