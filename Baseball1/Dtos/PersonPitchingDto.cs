namespace Baseball1.Dtos
{
    public class PersonPitchingDto
    {
        public string Name { get; set; }
        public int? TotalW { get; set; }
        public int? TotalL { get; set; }
        public int? TotalG { get; set; }
        public int? TotalGs { get; set; }
        public int? TotalCg { get; set; }
        public int? TotalSho { get; set; }
        public int? TotalSv { get; set; }
        public int? TotalIpouts { get; set; }
        public int? TotalH { get; set; }
        public int? TotalEr { get; set; }
        public int? TotalHr { get; set; }
        public int? TotalBb { get; set; }
        public int? TotalSo { get; set; }
        public int? TotalIbb { get; set; }
        public int? TotalWp { get; set; }
        public int? TotalHbp { get; set; }
        public int? TotalBk { get; set; }
        public int? TotalBfp { get; set; }
        public int? TotalGf { get; set; }
        public int? TotalR { get; set; }
        public int? TotalSf { get; set; }
        public int? TotalSh { get; set; }
        public int? TotalGidp { get; set; }
        public double TotalERA { get; set; }
        public double TotalH9 { get; set; }
        public double TotalHR9 { get; set; }
        public double TotalBB9 { get; set; }
        public double TotalSO9 { get; set; }
        public string TotalIP { get; set; }
        public double TotalWPct { get; set; }
        public double TotalOppBA { get; set; }
        public List<PitchingDto> PitchingLines { get; set; }

    }

    public class PitchingDto
    {
        public short YearId { get; set; }
        public short Stint { get; set; }
        public string? TeamId { get; set; }
        public string? LgId { get; set; }
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
