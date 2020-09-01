using TechTalkTestes.Domain.VendaCerveja.Entities;

namespace TechTalkTestes.Domain.VendaCerveja.Services
{
    public class VendaCervejaPremium : IVendaCerveja
    {
        public Cerveja CervejaParaVenda { get; private set; }
        public int QuantidadeParaVenda { get; private set; }
        public decimal ValorTotalDaVenda { get; private set; }

        public void VenderCerveja(Cerveja cerveja, int quantidade)
        {
            QuantidadeParaVenda = quantidade;
            CervejaParaVenda = cerveja;

            ValorTotalDaVenda = CalcularValorTotalVendaCervejaPremium(cerveja, quantidade);
        }

        private static decimal CalcularValorTotalVendaCervejaPremium(Cerveja cerveja, int quantidade)
        {
            return (cerveja.ValorUnitario + (cerveja.ValorUnitario * 0.1m)) * quantidade;
        }
    }
}
