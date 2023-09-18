using System;
using System.Collections.Generic;

namespace ProjectStomatology.Models
{
    public partial class DdiseaseHistory
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? PersonId { get; set; }
        public string HistoryText { get; set; } = null!;
        public DateTime DateAdd { get; set; }
        public bool IsRemove { get; set; }

        public virtual Rclient? Client { get; set; }
        public virtual Sperson? Person { get; set; }
    }
}
