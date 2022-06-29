using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class TeamsFranchise
    {
        public string FranchId { get; set; } = null!;
        public string? FranchName { get; set; }
        public string? Active { get; set; }
        public string? Naassoc { get; set; }
    }
}
