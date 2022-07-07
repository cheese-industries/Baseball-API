using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baseball1.Models
{
    public partial class Appearance
    {
        public short YearId { get; set; }
        public string TeamId { get; set; } = null!;
        public string? LgId { get; set; }
        public string PlayerId { get; set; } = null!;
        public short? GAll { get; set; }
        public short? Gs { get; set; }
        public short? GBatting { get; set; }
        public short? GDefense { get; set; }
        public short? GP { get; set; }
        public short? GC { get; set; }
        public short? G1b { get; set; }
        public short? G2b { get; set; }
        public short? G3b { get; set; }
        public short? GSs { get; set; }
        public short? GLf { get; set; }
        public short? GCf { get; set; }
        public short? GRf { get; set; }
        public short? GOf { get; set; }
        public short? GDh { get; set; }
        public short? GPh { get; set; }
        public short? GPr { get; set; }
        [ForeignKey("PlayerId")]
        public Person Person { get; set; }

        [ForeignKey("YearId, LgId, TeamId")]
        public Team Team { get; set; }
    }
}
