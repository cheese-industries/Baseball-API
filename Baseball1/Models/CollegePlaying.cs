using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class CollegePlaying
    {
        public string PlayerId { get; set; } = null!;
        public string? SchoolId { get; set; }
        public short? YearId { get; set; }
    }
}
