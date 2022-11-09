using System;
using System.Collections.Generic;

namespace ZemiBrojce.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public int? SalterId { get; set; }

        public virtual Salter IdNavigation { get; set; } = null!;
    }
}
