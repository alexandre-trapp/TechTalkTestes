using Npgsql;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalkTestes.Domain.Venda.Services;
using TechTalkTestes.Infra.Database.Postgres;
using static TechTalkTestes.Domain.Venda.Constants.VendaCervejaColumns;

namespace TechTalkTestes.Integration.Tests
{
    [TestFixture]
    public class ProgramaVendaCervejaTest
    {        
        [Test]
        public void deve_cadastrar_a_venda_de_10_cervejas_brahma_4_reais_cada_e_cinco_stella_6_reais_mais_3_porcento_na_base_de_dados_totalizando_uma_venda_de_73_reais()
        {
            // action
            var programaVenda = new ProgramaVendaCerveja(Repositories._vendaCervejaRepository);
            programaVenda.EfetuarVendaCerveja();

            var listaCervejasVendidas = ObterVendasDeCerveja();

            // verify
            const int BRAHMA = 0;
            const int STELLA = 1;

            Assert.AreEqual("brahma", listaCervejasVendidas[BRAHMA].Marca);
            Assert.AreEqual(4.00m, listaCervejasVendidas[BRAHMA].ValorUnitario);
            Assert.AreEqual(10, listaCervejasVendidas[BRAHMA].Quantidade);
            Assert.AreEqual(40.00m, listaCervejasVendidas[BRAHMA].ValorTotalVenda);

            Assert.AreEqual("stella artois", listaCervejasVendidas[STELLA].Marca);
            Assert.AreEqual(6.00m, listaCervejasVendidas[STELLA].ValorUnitario);
            Assert.AreEqual(5, listaCervejasVendidas[STELLA].Quantidade);
            Assert.AreEqual(33.00m, listaCervejasVendidas[STELLA].ValorTotalVenda);

            Assert.AreEqual(73.00m, (programaVenda.ValorTotalDasVendas));
        }

        private VendaCervejaValidate[] ObterVendasDeCerveja()
        {
            using var conn = DatabaseServices.OpenConnection();
            using var command = new NpgsqlCommand("SELECT marca, valor_unitario, quantidade_vendida, valor_total_venda FROM vendas_cerveja", conn);

            var vendas = command.ExecuteReader();

            var listaVendasCervejas = new List<VendaCervejaValidate>();

            while (vendas.Read())
            {
                VendaCervejaValidate venda;
                venda.Marca = vendas.GetString(MARCA);
                venda.ValorUnitario = vendas.GetDecimal(VALOR_UNITARIO);
                venda.Quantidade = vendas.GetInt32(QUANTIDADE_VENDIDA);
                venda.ValorTotalVenda = vendas.GetDecimal(VALOR_TOTAL_VENDA);

                listaVendasCervejas.Add(venda);
            }

            conn.Close();

            return listaVendasCervejas.ToArray();
        }

        [TearDown]
        public void limpar_dados_de_teste_da_tabela_de_venda()
        {
            using var conn = DatabaseServices.OpenConnection();

            using var command = new NpgsqlCommand("DELETE FROM vendas_cerveja", conn);
            command.ExecuteNonQuery();

            conn.Close();
        }
    }

    internal struct VendaCervejaValidate
    {
        internal string Marca;
        internal decimal ValorUnitario;
        internal int Quantidade;
        internal decimal ValorTotalVenda;
    }
}