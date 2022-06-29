using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class AllstarFull
    {
        public string? PlayerId { get; set; }
        public int? YearId { get; set; }
        public int? GameNum { get; set; }
        public string? GameId { get; set; }
        public string? TeamId { get; set; }
        public string? LgId { get; set; }
        public int? Gp { get; set; }
        public string? StartingPos { get; set; }
    }
}
