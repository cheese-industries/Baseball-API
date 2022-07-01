namespace Baseball1.Dtos
{
    public class PersonBattingDto
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string BirthDate { get; set; }
        public DateTime BirthDateTime { get; set; }
        public DateTime? DeathDateTime { get; set; }
        public string BirthState { get; set; }
        public string? DeathCity { get; set; }
        public string? DeathCountry { get; set; }
        //public string DeathDate { get; set; }
        public string DeathState { get; set; }
        public bool IsDeceased { get; set; }
        public string? Bats { get; set; }
        public string? Throws { get; set; }
        public int TotalG { get; set; }
        public int TotalAB { get; set; }
        public int TotalR { get; set; }
        public int TotalH { get; set; }
        public int TotalRBI { get; set; }
        public int Total2B { get; set; }
        public int Total3B { get; set; }
        public int TotalHR { get; set; }
        public int TotalBB { get; set; }
        public int TotalSO { get; set; }
        public int TotalSB { get; set; }
        public int TotalCS { get; set; }
        public int TotalHBP { get; set; }
        public int TotalIBB { get; set; }
        public int TotalGIDP { get; set; }
        public int TotalSH { get; set; }
        public int TotalSF { get; set; }
        public float CareerBA { get; set; }
        public float CareerOBP { get; set; }
        public float CareerSLG { get; set; }


        public List<BattingDto> BattingLines { get; set; }
        public List<TeamBattingSummaryDto> TeamSummaries { get; set; }
    }
    public class BattingDto
    {
        public short YearId { get; set; }
        public string? TeamId { get; set; }
        public short G { get; set; }
        public short Ab { get; set; }
        public short R { get; set; }
        public short H { get; set; }
        public short _2b { get; set; }
        public short _3b { get; set; }
        public short Hr { get; set; }
        public short Rbi { get; set; }
        public short Sb { get; set; }
        public short Cs { get; set; }
        public short Bb { get; set; }
        public short So { get; set; }
        public short Ibb { get; set; }
        public short Hbp { get; set; }
        public short Sh { get; set; }
        public short Sf { get; set; }
        public short Gidp { get; set; }

        public double BA { get; set; }
        public double OBP { get; set; }
        public double SLG { get; set; }

    }
}
