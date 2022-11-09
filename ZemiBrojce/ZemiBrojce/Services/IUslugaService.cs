using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public interface IUslugaService
    {
        public List<Usluga> GetUsluga();
        public Usluga ChoseUsluga(int id);
    }
}
