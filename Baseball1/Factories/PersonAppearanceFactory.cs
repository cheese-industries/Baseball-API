namespace Baseball1.Factories
{
    public class PersonAppearanceFactory
    {
        public static Dtos.PersonAppearanceDto ToDto(Person person)
        {
            return new Dtos.PersonAppearanceDto
            {
                AppearanceLines = person.AppearanceSeasons.Select(b => GetAppearanceLine(b)).ToList(),
                TeamSummaries = CreateTeamSummary(person.AppearanceSeasons.Select(b => GetAppearanceLine(b)).ToList()),
            };
        }

        private static Dtos.AppearanceDto GetAppearanceLine(Appearance appearance)
        {
            return new Dtos.AppearanceDto
            {
                YearId = appearance.YearId,
                TeamId = appearance.TeamId,
                PlayerId = appearance.PlayerId,
                GAll = appearance.GAll,
                Gs = appearance.Gs,
                GBatting = appearance.GBatting,
                GDefense = appearance.GDefense,
                GP = appearance.GP,
                GC = appearance.GC,
                G1b = appearance.G1b,
                G2b = appearance.G2b,
                G3b = appearance.G3b,
                GSs = appearance.GSs,
                GLf = appearance.GLf,
                GCf = appearance.GCf,
                GRf = appearance.GRf,
                GOf = appearance.GOf,
                GDh = appearance.GDh,
                GPh = appearance.GPh,
                GPr = appearance.GPr,
            };
        }

        private static List<Dtos.TeamAppearanceSummaryDto> CreateTeamSummary(List<Dtos.AppearanceDto> appearanceLines)
        {
            var TeamSummaries = new List<Dtos.TeamAppearanceSummaryDto>();
            var UniqueTeams = appearanceLines.Select(t => t.TeamId).Distinct();
            foreach (var team in UniqueTeams)
            {
                var teamAppearanceLines = appearanceLines.Where(t => t.TeamId == team);
                var teamSummary = new Dtos.TeamAppearanceSummaryDto
                {
                    TeamId = team,
                    GAll = (short)teamAppearanceLines.Sum(t => t.GAll),
                    Gs = (short)teamAppearanceLines.Sum(t => t.Gs),
                    GBatting = (short)teamAppearanceLines.Sum(t => t.GBatting),
                    GDefense = (short)teamAppearanceLines.Sum(t => t.GDefense),
                    GP = (short)teamAppearanceLines.Sum(t => t.GP),
                    GC = (short)teamAppearanceLines.Sum(t => t.GC),
                    G1b = (short)teamAppearanceLines.Sum(t => t.G1b),
                    G2b = (short)teamAppearanceLines.Sum(t => t.G2b),
                    G3b = (short)teamAppearanceLines.Sum(t => t.G3b),
                    GSs = (short)teamAppearanceLines.Sum(t => t.GSs),
                    GLf = (short)teamAppearanceLines.Sum(t => t.GLf),
                    GCf = (short)teamAppearanceLines.Sum(t => t.GCf),
                    GRf = (short)teamAppearanceLines.Sum(t => t.GRf),
                    GOf = (short)teamAppearanceLines.Sum(t => t.GOf),
                    GDh = (short)teamAppearanceLines.Sum(t => t.GDh),
                    GPh = (short)teamAppearanceLines.Sum(t => t.GPh),
                    GPr = (short)teamAppearanceLines.Sum(t => t.GPr),
                };
                TeamSummaries.Add(teamSummary);
            }
            return TeamSummaries;
        }
    }
}
