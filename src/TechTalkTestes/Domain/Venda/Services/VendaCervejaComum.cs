using TechTalkTestes.Domain.Venda.Entities;

namespace TechTalkTestes.Domain.Venda.Services
{
    public class VendaCervejaComum : VendaCerveja
    {
        public override void VenderCerveja(Cerveja cerveja, int quantidade)
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