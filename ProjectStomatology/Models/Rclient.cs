using System;
using System.Collections.Generic;

namespace ProjectStomatology.Models
{
    public partial class Rclient
    {
        public Rclient()
        {
            DdiseaseHistories = new HashSet<DdiseaseHistory>();
            JdiseaseHistories = new HashSet<JdiseaseHistory>();
            VisitHistories = new HashSet<VisitHistory>();
        }

        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public bool IsRemove { get; set; }
        public int Sex { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? PolicyNumber { get; set; }
        public string? Snils { get; set; }
        public int? PassportNumber { get; set; }
        public int? PassportSeria { get; set; }
        public string? Treatment { get; set; }
        public string? Dentist { get; set; }
        public decimal? Payment { get; set; }

        public virtual ICollection<DdiseaseHistory> DdiseaseHistories { get; set; }
        public virtual ICollection<JdiseaseHistory> JdiseaseHistories { get; set; }
        public virtual ICollection<VisitHistory> VisitHistories { get; set; }
    }
}
