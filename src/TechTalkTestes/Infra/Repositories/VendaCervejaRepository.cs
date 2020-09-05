using Npgsql;
using System.Text;
using TechTalkTestes.Domain.Venda.Entities;
using TechTalkTestes.Domain.Venda.Repositories;
using static TechTalkTestes.Domain.Venda.Constants.VendaCervejaColumns;

namespace TechTalkTestes.Infra.Database.Repositories
{
    public class VendaCervejaRepository : IVendaCervejaRepository
    {
        private readonly NpgsqlConnection _conn;

        public VendaCervejaRepository(NpgsqlConnection conn)
        {
            _conn = conn;
        }

        public void ExcluirTodasAsVendas()
        {
            using var command = new NpgsqlCommand("DELETE FROM vendas_cerveja", _conn);
            command.ExecuteNonQuery();
        }

        public void CadastrarVenda(VendaCerveja vendaCerveja)
        {
            using var command = new NpgsqlCommand("INSERT INTO vendas_cerveja(marca, valor_unitario, quantidade_vendida, valor_total_venda) " +
                "VALUES (@marca, @valor_unitario, @quantidade_vendida, @valor_total_venda)", _conn);

            command.Parameters.Add(new NpgsqlParameter("marca", vendaCerveja.CervejaParaVenda.Marca));
            command.Parameters.Add(new NpgsqlParameter("valor_unitario", vendaCerveja.CervejaParaVenda.ValorUnitario));
            command.Parameters.Add(new NpgsqlParameter("quantidade_vendida", vendaCerveja.QuantidadeParaVenda));
            command.Parameters.Add(new NpgsqlParameter("valor_total_venda", vendaCerveja.ValorTotalDaVenda));

            command.ExecuteNonQuery();
        }

        public string ListarTodasAsVendas()
        {
            using var command = new NpgsqlCommand("SELECT marca, valor_unitario, quantidade_vendida, valor_total_venda FROM vendas_cerveja", _conn);
            var vendas = command.ExecuteReader();

            var listaVendasCervejas = new StringBuilder();
            listaVendasCervejas.AppendLine();

            while (vendas.Read())
            {
                listaVendasCervejas.AppendLine(vendas.GetString(MARCA) + " - R$ " + vendas.GetDecimal(VALOR_UNITARIO) + " - "
                    + vendas.GetInt32(QUANTIDADE_VENDIDA) + " - " + vendas.GetDecimal(VALOR_TOTAL_VENDA));

                listaVendasCervejas.AppendLine();
            }

            return listaVendasCervejas.ToString();
        }
    }
}
