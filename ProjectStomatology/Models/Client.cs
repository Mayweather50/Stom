using System;
using System.Collections.Generic;

namespace ProjectStomatology.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string? Fio { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Pasport { get; set; }
        public string? DiseaseHistory { get; set; }
    }
}
