using System;
using System.Collections.Generic;

namespace ZemiBrojce.Models
{
    public partial class Broj
    {
        public int Id { get; set; }
        public DateTime? Generiran { get; set; }
        public int? UslugaId { get; set; }
        public int? SalterId { get; set; }
        public int? NajnovBroj { get; set; }
        public int? MomentalenBroj { get; set; }

        public virtual Salter? Salter { get; set; }
        public virtual Usluga? Usluga { get; set; }
    }
}
