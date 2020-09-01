using System.Text;

namespace TechTalkTestes.Domain.VendaCerveja.Services
{
    public class EmissaoCupomVenda
    {
        public string EmitirCupomDaVenda(VendaCervejaComum vendaCerveja)
        {
            var cupomVenda = new StringBuilder();

            cupomVenda.AppendLine($"-- Cerveja -- Valor unitário -- Quantidade da Venda -- Valor total da Venda");
            cupomVenda.AppendLine($"{vendaCerveja.CervejaParaVenda.Marca} -- R$ {vendaCerveja.CervejaParaVenda.ValorUnitario} -- " +
                                  $"{vendaCerveja.QuantidadeParaVenda} -- {vendaCerveja.ValorTotalDaVenda}");

            return cupomVenda.ToString();
        }
    }
}
