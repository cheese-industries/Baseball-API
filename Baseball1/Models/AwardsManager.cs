using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class AwardsManager
    {
        public string PlayerId { get; set; } = null!;
        public string AwardId { get; set; } = null!;
        public short YearId { get; set; }
        public string LgId { get; set; } = null!;
        public string? Tie { get; set; }
        public string? Notes { get; set; }
    }
}
