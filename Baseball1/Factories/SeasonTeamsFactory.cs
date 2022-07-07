namespace Baseball1.Factories
{
    public class SeasonTeamsFactory
    {
        public static Dtos.SeasonTeamsDto ToDto(Team team)
        {
            return new Dtos.SeasonTeamsDto
            {
                //SeasonTeams = team.TeamSeasons.Select(t => GetTeamSeason(t)).ToList(),
            };
        }
        private static Dtos.TeamsDto GetTeamSeason(Team team)
        {
            return new Dtos.TeamsDto
            {
                YearId = team.YearId,
                LgId = team.LgId,
                TeamId = team.TeamId,
                FranchId = team.FranchId,
                DivId = team.DivId,
                Rank = team.Rank,
                G = team.G,
                W = team.W,
                L = team.L,
                DivWin = team.DivWin,
                Wcwin = team.Wcwin,
                LgWin = team.LgWin,
                Wswin = team.Wswin,
                R = team.R,
                Ra = team.Ra,
                Name = team.Name,
            };
        }
    }
}
