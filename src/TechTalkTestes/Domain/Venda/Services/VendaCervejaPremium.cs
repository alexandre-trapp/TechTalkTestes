using System;
using TechTalkTestes.Domain.Venda.Entities;

namespace TechTalkTestes.Domain.Venda.Services
{
    public class VendaCervejaPremium : VendaCerveja
    {
        public override void VenderCerveja(Cerveja cerveja, int quantidade)
        {
            if (!cerveja.Premium)
                throw new OperationCanceledException("Tipo da cerveja deve ser 'Premium' para utilizar este tipo de venda.");

            QuantidadeParaVenda = quantidade;
            CervejaParaVenda = cerveja;

            ValorTotalDaVenda = CalcularValorTotalVendaCervejaPremium(cerveja, quantidade);
        }

        private static decimal CalcularValorTotalVendaCervejaPremium(Cerveja cerveja, int quantidade)
        {
            return (cerveja.ValorUnitario * quantidade) + SomarDezPorcentoDoValorTotal(cerveja, quantidade);
        }

        private static decimal SomarDezPorcentoDoValorTotal(Cerveja cerveja, int quantidade)
        {
            const decimal VALOR_DEZ_PORCENTO = 0.1m;
            return (cerveja.ValorUnitario * quantidade) * VALOR_DEZ_PORCENTO;
        }
    }
}
