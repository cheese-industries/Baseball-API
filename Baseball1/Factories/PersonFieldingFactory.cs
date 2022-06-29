namespace Baseball1.Factories
{
    public class PersonFieldingFactory
    {
        public static Dtos.PersonFieldingDto ToDto(Person person)
        {
            return new Dtos.PersonFieldingDto
            {
                FieldingLines = person.FieldingSeasons.Select(f => GetFieldingLine(f)).ToList()
            };
        }

        private static Dtos.FieldingDto GetFieldingLine(Fielding fielding)
        {
            return new Dtos.FieldingDto
            {
                YearId = fielding.YearId,
                TeamId = fielding.TeamId,
                Pos = fielding.Pos,
                G = fielding.G,
                Gs = fielding.Gs,
                InnOuts = fielding.InnOuts,
                Po = fielding.Po,
                A = fielding.A,
                E = fielding.E,
                Dp = fielding.Dp,
                Pb = fielding.Pb,
                Wp = fielding.Wp,
                Sb = fielding.Sb,
                Cs = fielding.Cs
            };
        }
    }
}
