using TechTalkTestes.Domain.VendaCerveja.Entidades;

namespace TechTalkTestes.Domain.VendaCerveja.Servicos
{
    public class VendaCerveja
    {
        public Cerveja CervejaParaVenda { get; private set; }
        public int QuantidadeParaVenda { get; private set; }
        public decimal ValorTotalDaVenda { get; private set; }

        public void VendarCerveja(Cerveja cerveja, int quantidade)
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
