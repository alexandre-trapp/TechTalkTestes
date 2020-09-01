namespace TechTalkTestes.Domain.VendaCerveja.Entities
{
    public class Cerveja
    {
        public string Marca { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public Cerveja(string marca, decimal valorUnitario)
        {
            Marca = marca;
            ValorUnitario = valorUnitario;
        }
    }
}