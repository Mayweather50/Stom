using System;
using System.Collections.Generic;

namespace ProjectStomatology.Models
{
    public partial class VisitHistory
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ClientId { get; set; }
        public DateTime DatetimeVisit { get; set; }
        public bool IsHappened { get; set; }
        public bool IsRemove { get; set; }
        public int? SpecialtiesIds { get; set; }

        public virtual Rclient Client { get; set; } = null!;
        public virtual Sperson Person { get; set; } = null!;
    }
}
