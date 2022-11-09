using System;
using System.Collections.Generic;

namespace ZemiBrojce.Models
{
    public partial class Salter
    {
        public Salter()
        {
            Brojs = new HashSet<Broj>();
            SalterUslugas = new HashSet<SalterUsluga>();
        }

        public int Id { get; set; }
        public string? SalterIme { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Broj> Brojs { get; set; }
        public virtual ICollection<SalterUsluga> SalterUslugas { get; set; }
    }
}
