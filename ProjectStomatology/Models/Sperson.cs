using System;
using System.Collections.Generic;

namespace ProjectStomatology.Models
{
    public partial class Sperson
    {
        public Sperson()
        {
            DdiseaseHistories = new HashSet<DdiseaseHistory>();
            JdiseaseHistories = new HashSet<JdiseaseHistory>();
            VisitHistories = new HashSet<VisitHistory>();
        }

        public int Id { get; set; }
        public string AspNetUserEmail { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public bool IsRemove { get; set; }

        public virtual ICollection<DdiseaseHistory> DdiseaseHistories { get; set; }
        public virtual ICollection<JdiseaseHistory> JdiseaseHistories { get; set; }
        public virtual ICollection<VisitHistory> VisitHistories { get; set; }
    }
}
