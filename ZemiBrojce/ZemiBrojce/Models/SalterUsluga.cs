using System;
using System.Collections.Generic;

namespace ZemiBrojce.Models
{
    public partial class SalterUsluga
    {
        public int Id { get; set; }
        public int? SalterId { get; set; }
        public int? UslugaId { get; set; }

        public virtual Salter? Salter { get; set; }
        public virtual Usluga? Usluga { get; set; }
    }
}
