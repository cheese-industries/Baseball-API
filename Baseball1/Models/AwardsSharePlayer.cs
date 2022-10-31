using System;
using System.Collections.Generic;

namespace Baseball1
{
    public partial class AwardsSharePlayer
    {
        public string AwardId { get; set; } = null!;
        public short YearId { get; set; }
        public string LgId { get; set; } = null!;
        public string PlayerId { get; set; } = null!;
        public double? PointsWon { get; set; }
        public short? PointsMax { get; set; }
        public double? VotesFirst { get; set; }
        public byte[] SsmaTimeStamp { get; set; } = null!;
    }
}
