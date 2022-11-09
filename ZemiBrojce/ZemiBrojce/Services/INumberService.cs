using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public interface INumberService
    {
        public Broj GetNumber(int uslugaId);
        
        public Broj NextNumber(int uslugaId);
    }
}
