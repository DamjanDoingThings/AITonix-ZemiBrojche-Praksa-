using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public class UslugaService : IUslugaService
    {
        private readonly Praksa_ZemiBrojContext _db;

        public UslugaService(Praksa_ZemiBrojContext db)
        {
            _db = db;
        }

        //Function where the client selects what task he needs from already defined tasks

        public Usluga ChoseUsluga(int id)
        {
            var chose = _db.Uslugas.FirstOrDefault(x => x.Id == id);
            return chose!;
        }

        //Function for listing all task that are defined from the workers

        public List<Usluga> GetUsluga()
        {
            var uslugi =_db.Uslugas.ToList();
            return uslugi;
        }
    }
}
