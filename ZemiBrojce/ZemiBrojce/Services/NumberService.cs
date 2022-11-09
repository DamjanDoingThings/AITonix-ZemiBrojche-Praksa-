using Microsoft.EntityFrameworkCore;
using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public class NumberService : INumberService
    {
        public readonly Praksa_ZemiBrojContext _db;

        public NumberService(Praksa_ZemiBrojContext db)
        {
            _db = db;
        }
        
        //Function where the client gets number

        public Broj GetNumber(int uslugaId)
        {
            DateTime currDate = DateTime.Now;
            int currDateDay = currDate.Day;


            var salterId = _db.SalterUslugas.FirstOrDefault(x => x.UslugaId == uslugaId);
            var broj = _db.Brojs.FirstOrDefault(x => x.SalterId == salterId!.SalterId);

            DateTime? tempDate = broj.Generiran;
            int? tempDateDay = tempDate?.Day;            

            broj.Generiran = currDate;

            var brojIzdaden = broj!.NajnovBroj;

            if (currDateDay != tempDateDay)
            {
                var resetBroj = _db.Brojs.ToList();
                foreach (var cust in resetBroj)
                {
                    cust.NajnovBroj = 1;
                    // broj.MomentalenBroj = 1;
                }
                
            }
            else {
                broj.NajnovBroj += 1;
            }

            var salter = _db.Update(broj);
             _db.SaveChangesAsync();

            return broj;
        }

        public Broj NextNumber(int uslugaId)
        {
            var salterId = _db.SalterUslugas.FirstOrDefault(x => x.UslugaId == uslugaId);

            var broj = _db.Brojs.FirstOrDefault(x => x.SalterId == salterId!.SalterId);

            var momentalenBroj = broj!.MomentalenBroj;
            var najnovBroj = broj!.NajnovBroj;

            if (momentalenBroj < najnovBroj)
            {
                broj.MomentalenBroj += 1;
            }  

            var salter = _db.Update(broj);
            _db.SaveChangesAsync();

            return broj;

        }
    }
}
