namespace Baseball1.Dtos
{
    public class SeasonTeamsDto
    {
        public List<TeamsDto> SeasonTeams { get; set; }
    }

    public class TeamsDto
    {
        public short YearId { get; set; }
        public string LgId { get; set; } = null!;
        public string TeamId { get; set; } = null!;
        public string? FranchId { get; set; }
        public string? DivId { get; set; }
        public short? Rank { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public string? DivWin { get; set; }
        public string? Wcwin { get; set; }
        public string? LgWin { get; set; }
        public string? Wswin { get; set; }
        public short? R { get; set; }
        public short? Ra { get; set; }
        public string? Name { get; set; }
    }
}
