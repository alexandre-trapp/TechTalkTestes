using NUnit.Framework;
using TechTalkTestes.Domain.VendaCerveja.Servicos;
using TechTalkTestes.Domain.VendaCerveja.Entidades;

namespace TechTalkTestes.Unit.Tests
{
    public class Tests
    {
        [Test]
        public void deve_Vendar_quatro_cerveja_da_marca_skol_por_4_reais_totalizando_16_reais_a_Venda()
        {
            // prepare
            var cervejaSkol = new Cerveja("skol", 4.0m);
            var vendaCerveja = new VendaCerveja();

            // action
            vendaCerveja.VendarCerveja(
                cerveja: cervejaSkol, 
                quantidade: 4);

            // verify
            Assert.AreEqual(16.00m, vendaCerveja.ValorTotalDaVenda);
        }
    }
}