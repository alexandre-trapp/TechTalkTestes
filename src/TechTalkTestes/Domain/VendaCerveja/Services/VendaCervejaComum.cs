using TechTalkTestes.Domain.VendaCerveja.Entities;

namespace TechTalkTestes.Domain.VendaCerveja.Services
{
    public class VendaCervejaComum : IVendaCerveja
    {
        public Cerveja CervejaParaVenda { get; private set; }
        public int QuantidadeParaVenda { get; private set; }
        public decimal ValorTotalDaVenda { get; private set; }

        public void VenderCerveja(Cerveja cerveja, int quantidade)
        {
            CervejaParaVenda = cerveja;
            QuantidadeParaVenda = quantidade;

            CalcularTotalDaVenda();
        }

        private void CalcularTotalDaVenda()
        {
            ValorTotalDaVenda = CervejaParaVenda.ValorUnitario * QuantidadeParaVenda;
        }
    }
}