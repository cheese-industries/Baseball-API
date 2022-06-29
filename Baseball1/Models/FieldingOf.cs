using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class FieldingOf
    {
        public string PlayerId { get; set; } = null!;
        public short YearId { get; set; }
        public short Stint { get; set; }
        public short? Glf { get; set; }
        public short? Gcf { get; set; }
        public short? Grf { get; set; }
    }
}
