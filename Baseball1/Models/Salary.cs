using System;
using System.Collections.Generic;

namespace Baseball1
{
    public partial class Salary
    {
        public short YearId { get; set; }
        public string TeamId { get; set; } = null!;
        public string LgId { get; set; } = null!;
        public string PlayerId { get; set; } = null!;
        public double? Salary1 { get; set; }
        public byte[] SsmaTimeStamp { get; set; } = null!;
    }
}
