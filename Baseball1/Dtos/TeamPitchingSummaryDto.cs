﻿namespace Baseball1.Dtos
{
    public class TeamPitchingSummaryDto
    { 
        public string? TeamId { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public double? WPct { get; set; }
        public double era { get; set; }
        public double h9 { get; set; }
        public double hr9 { get; set; }
        public double bb9 { get; set; }
        public double so9 { get; set; }

        public short? G { get; set; }
        public short? Gs { get; set; }
        public short? Cg { get; set; }
        public short? Sho { get; set; }
        public short? Sv { get; set; }
        public int? Ipouts { get; set; }
        public string Ip { get; set; }
        public short? H { get; set; }
        public short? Er { get; set; }
        public short? Hr { get; set; }
        public short? Bb { get; set; }
        public short? So { get; set; }
        public decimal Oppba { get; set; }
        //public double? Era { get; set; }
        public short? Ibb { get; set; }
        public short? Wp { get; set; }
        public short? Hbp { get; set; }
        public short? Bk { get; set; }
        public short? Bfp { get; set; }
        public short? Gf { get; set; }
        public short? R { get; set; }
        public short? Sh { get; set; }
        public short? Sf { get; set; }
        public short? Gidp { get; set; }
    }

}
