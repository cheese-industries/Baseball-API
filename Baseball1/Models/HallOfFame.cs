using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class HallOfFame
    {
        public string PlayerId { get; set; } = null!;
        public short Yearid { get; set; }
        public string VotedBy { get; set; } = null!;
        public short? Ballots { get; set; }
        public short? Needed { get; set; }
        public short? Votes { get; set; }
        public string? Inducted { get; set; }
        public string? Category { get; set; }
        public string? NeededNote { get; set; }
    }
}
