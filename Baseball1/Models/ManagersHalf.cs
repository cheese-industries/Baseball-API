using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class ManagersHalf
    {
        public string PlayerId { get; set; } = null!;
        public short YearId { get; set; }
        public string TeamId { get; set; } = null!;
        public string? LgId { get; set; }
        public short? Inseason { get; set; }
        public short Half { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public short? Rank { get; set; }
    }
}
