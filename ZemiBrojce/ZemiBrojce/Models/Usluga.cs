using System;
using System.Collections.Generic;

namespace ZemiBrojce.Models
{
    public partial class Usluga
    {
        public Usluga()
        {
            Brojs = new HashSet<Broj>();
            SalterUslugas = new HashSet<SalterUsluga>();
        }

        public int Id { get; set; }
        public string? ImeUsluga { get; set; }

        public virtual ICollection<Broj> Brojs { get; set; }
        public virtual ICollection<SalterUsluga> SalterUslugas { get; set; }
    }
}
