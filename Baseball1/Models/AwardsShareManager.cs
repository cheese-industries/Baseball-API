﻿using System;
using System.Collections.Generic;

namespace Baseball1
{
    public partial class AwardsShareManager
    {
        public string AwardId { get; set; } = null!;
        public short YearId { get; set; }
        public string LgId { get; set; } = null!;
        public string PlayerId { get; set; } = null!;
        public short? PointsWon { get; set; }
        public short? PointsMax { get; set; }
        public short? VotesFirst { get; set; }
    }
}
