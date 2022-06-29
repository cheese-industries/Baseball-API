namespace Baseball1.Factories
{
    public class PersonAppearanceFactory
    {
        public static Dtos.PersonAppearanceDto ToDto(Person person)
        {
            return new Dtos.PersonAppearanceDto
            {
                AppearanceLines = person.AppearanceSeasons.Select(b => GetAppearanceLine(b)).ToList(),

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
    }
}
