using System;
using NUnit.Framework;
using TechTalkTestes.Domain.Venda.Entities;
using TechTalkTestes.Domain.Venda.Services;

namespace TechTalkTestes.Unit.Tests.Domain.Services
{
    [TestFixture]
    public class VendaPremiumTest
    {
        [Test]
        public void deve_ocorrer_erro_se_tentar_vender_cerveja_premium_com_uma_cerveja_comum()
        {
            // prepare
            var cervejaSkol = new Cerveja(marca: "skol", valorUnitario: 4.0m, cervejaPremium: false);
            var vendaCervejaPremium = new VendaCervejaPremium();

            // verify
            Assert.Throws<OperationCanceledException>(() => vendaCervejaPremium.VenderCerveja(
                cerveja: cervejaSkol,
                quantidade: 1));
        }
    }
}
