using TechTalkTestes.Domain.Venda.Services;

namespace TechTalkTestes.Domain.Venda.Repositories
{
    public interface IVendaCervejaRepository
    {
        void ExcluirTodasAsVendas();
        void CadastrarVenda(VendaCerveja vendaCerveja);
        string ListarTodasAsVendas();
    }
}
