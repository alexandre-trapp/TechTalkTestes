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
            using var command = new NpgsqlCommand("INSERT INTO VENDAS_CERVEJA(MARCA, VALOR_UNITARIO, QUANTIDADE_VENDIDA, VALOR_TOTAL_VENDA) " +
                "VALUES (@MARCA, @VALOR_UNITARIO, @QUANTIDADE_VENDIDA, @VALOR_TOTAL_VENDA)", _conn);

            command.Parameters.Add(new NpgsqlParameter("MARCA", vendaCerveja.CervejaParaVenda.Marca));
            command.Parameters.Add(new NpgsqlParameter("VALOR_UNITARIO", vendaCerveja.CervejaParaVenda.ValorUnitario));
            command.Parameters.Add(new NpgsqlParameter("QUANTIDADE_VENDIDA", vendaCerveja.QuantidadeParaVenda));
            command.Parameters.Add(new NpgsqlParameter("VALOR_TOTAL_VENDA", vendaCerveja.ValorTotalDaVenda));

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
