namespace TechTalkTestes.Domain.Venda.Entities
{
    public class Cerveja
    {
        public string Marca { get; private set; }
        public bool Premium { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public Cerveja(string marca, decimal valorUnitario, bool cervejaPremium = false)
        {
            Marca = marca;
            ValorUnitario = valorUnitario;
            Premium = cervejaPremium;
        }
    }
}