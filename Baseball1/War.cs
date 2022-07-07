using System;
using System.Collections.Generic;

namespace Baseball1
{
    public partial class War
    {
        public string Name { get; set; } = null!;
        public string BbrefId { get; set; } = null!;
        public short YearId { get; set; }
        public string TeamId { get; set; } = null!;
        public byte StintId { get; set; }
        public string LgId { get; set; } = null!;
        public double? BatWaa { get; set; }
        public double? BatWar { get; set; }
        public double? PitWar { get; set; }
        public double? PitWaa { get; set; }
        public double? War1 { get; set; }
        public double? Waa { get; set; }
    }
}
