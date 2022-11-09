using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public class SalterService : ISalterService
    {
        private readonly Praksa_ZemiBrojContext _db;

        public SalterService(Praksa_ZemiBrojContext db)
        {
            _db = db;
        }

        //Fuction where the worker choses the current number

        public Broj GetSalterNumber(int salterId)
        {
            var data = _db.Brojs.FirstOrDefault(x => x.SalterId == salterId);
            return data!;
        }
    }
}
