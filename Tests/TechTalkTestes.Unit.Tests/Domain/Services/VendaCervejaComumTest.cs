using NUnit.Framework;
using TechTalkTestes.Domain.VendaCerveja.Services;
using TechTalkTestes.Domain.VendaCerveja.Entities;

namespace TechTalkTestes.Unit.Tests.Domain.Services
{
    [TestFixture]
    public class VendaCervejaComumTest
    {
        [Test]
        public void deve_vender_quatro_cervejas_da_marca_skol_por_4_reais_totalizando_16_reais_a_venda()
        {
            // prepare
            var cervejaSkol = new Cerveja(marca: "skol", valorUnitario: 4.0m);
            var vendaCervejaComum = new VendaCervejaComum();

            // action
            vendaCervejaComum.VenderCerveja(
                cerveja: cervejaSkol, 
                quantidade: 4);

            // verify
            Assert. AreEqual(16.00m, vendaCervejaComum.ValorTotalDaVenda);
        }
    }
}