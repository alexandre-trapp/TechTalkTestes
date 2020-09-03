using Npgsql;
using System.Text;
using TechTalkTestes.Domain.Venda.Services;

namespace TechTalkTestes.Domain.Venda.Repositories
{
    public class VendaCervejaRepository : IVendaCervejaRepository
    {
        private readonly NpgsqlConnection _conn;

        public VendaCervejaRepository(NpgsqlConnection conn)
        {
            _conn = conn;
        }

        public void CadastrarVenda(VendaCerveja vendaCerveja)
        {
            using var command = new NpgsqlCommand("insert into vendas_cerveja(marca, valor_unitario, quantidade_vendida, valor_total_venda) " +
                "values (@marca, @valor_unitario, @quantidade_vendida, @valor_total_venda)", _conn);

            command.Parameters.Add(new NpgsqlParameter("marca", vendaCerveja.CervejaParaVenda.Marca));
            command.Parameters.Add(new NpgsqlParameter("valor_unitario", vendaCerveja.CervejaParaVenda.ValorUnitario));
            command.Parameters.Add(new NpgsqlParameter("quantidade_vendida", vendaCerveja.QuantidadeParaVenda));
            command.Parameters.Add(new NpgsqlParameter("valor_total_venda", vendaCerveja.ValorTotalDaVenda));

            command.ExecuteNonQuery();
        }

        public string ListarTodasAsVendas()
        {
            const int MARCA = 0;
            const int VALOR_UNITARIO = 1;
            const int QUANTIDADE_VENDIDA = 2;
            const int VALOR_TOTAL_VENDA = 3;

            using var command = new NpgsqlCommand("SELECT MARCA, VALOR_UNITARIO, QUANTIDADE_VENDIDA, VALOR_TOTAL_VENDA FROM VENDAS_CERVEJA", _conn);
            var vendas = command.ExecuteReader();

            var listaVendasCervejas = new StringBuilder("Lista das vendas realizadas:");
            listaVendasCervejas.AppendLine();

            while (vendas.Read())
            {
                listaVendasCervejas.Append(vendas.GetString(MARCA) + " - R$ " + vendas.GetString(VALOR_UNITARIO) + " - "
                    + vendas.GetString(QUANTIDADE_VENDIDA) + " - " + vendas.GetString(VALOR_TOTAL_VENDA));

                listaVendasCervejas.AppendLine();
            }

            return listaVendasCervejas.ToString();
        }
    }
}
