using System;
using System.Collections.Generic;

namespace ProjectStomatology.Models
{
    public partial class Cspecialty
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsRemove { get; set; }
    }
}
