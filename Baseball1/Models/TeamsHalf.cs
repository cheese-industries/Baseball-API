using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class TeamsHalf
    {
        public short YearId { get; set; }
        public string LgId { get; set; } = null!;
        public string TeamId { get; set; } = null!;
        public string Half { get; set; } = null!;
        public string? DivId { get; set; }
        public string? DivWin { get; set; }
        public short? Rank { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
    }
}
