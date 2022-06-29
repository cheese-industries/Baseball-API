using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class School
    {
        public string SchoolId { get; set; } = null!;
        public string? NameFull { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
