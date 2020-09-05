namespace TechTalkTestes.Domain.Venda.Entities
{
    public abstract class VendaCerveja
    {
        public Cerveja CervejaParaVenda { get; protected set; }
        public int QuantidadeParaVenda { get; protected set; }
        public decimal ValorTotalDaVenda { get; protected set; }

        public abstract void VenderCerveja(Cerveja cerveja, int quantidade);
    }
}
