using NUnit.Framework;
using TechTalkTestes.Domain.VendaCerveja.Services;
using TechTalkTestes.Domain.VendaCerveja.Entities;

namespace TechTalkTestes.Unit.Tests.Domain.Services
{
    public class Tests
    {
        [Test]
        public void deve_vender_quatro_cerveja_da_marca_skol_por_4_reais_totalizando_16_reais_a_Venda()
        {
            // prepare
            var cervejaSkol = new Cerveja("skol", 4.0m);
            var vendaCerveja = new VendaCervejaComum();

            // action
            vendaCerveja.VenderCerveja(
                cerveja: cervejaSkol, 
                quantidade: 4);

            // verify
            Assert.AreEqual(16.00m, vendaCerveja.ValorTotalDaVenda);
        }
    }
}