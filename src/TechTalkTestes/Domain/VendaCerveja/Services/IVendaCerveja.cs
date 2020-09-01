using TechTalkTestes.Domain.VendaCerveja.Entities;

namespace TechTalkTestes.Domain.VendaCerveja.Services
{
    public interface IVendaCerveja
    {
        void VenderCerveja(Cerveja cerveja, int quantidade);
    }
}
