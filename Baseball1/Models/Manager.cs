using System;
using System.Collections.Generic;

namespace Baseball1
{
    public partial class Manager
    {
        public string? PlayerId { get; set; }
        public short YearId { get; set; }
        public string TeamId { get; set; } = null!;
        public string? LgId { get; set; }
        public short Inseason { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public short? Rank { get; set; }
        public string? PlyrMgr { get; set; }
    }
}
