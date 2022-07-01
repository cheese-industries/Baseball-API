namespace Baseball1.Factories
{
    public class PersonFieldingFactory
    {
        public static Dtos.PersonFieldingDto ToDto(Person person)
        {
            return new Dtos.PersonFieldingDto
            {
                FieldingLines = person.FieldingSeasons.Select(f => GetFieldingLine(f)).ToList(),
                //TeamSummaries = CreateTeamSummary(person.FieldingSeasons.Select(f => GetFieldingLine(f)).ToList())
                PositionSummaries = CreatePositionSummary(person.FieldingSeasons.Select(f => GetFieldingLine(f)).ToList()),
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

        private static List<Dtos.PositionFieldingSummaryDto> CreatePositionSummary(List<Dtos.FieldingDto> fieldingList)
        {
            var PositionSummaries = new List<Dtos.PositionFieldingSummaryDto>();
            var UniquePositions = fieldingList.Select(t => t.Pos).Distinct();
            foreach (var position in UniquePositions)
            {
                var positionLines = fieldingList.Where(t => t.Pos == position);
                var positionSummary = new Dtos.PositionFieldingSummaryDto
                {
                    Pos = position,
                    G = (short)positionLines.Sum(t => t.G),
                    Gs = (short)positionLines.Sum(t => t.Gs),
                    InnOuts = (short)positionLines.Sum(t => t.InnOuts),
                    Po = (short)positionLines.Sum(t => t.Po),
                    A = (short)positionLines.Sum(t => t.A),
                    E = (short)positionLines.Sum(t => t.E),
                    Dp = (short)positionLines.Sum(t => t.Dp),
                    Pb = (short)positionLines.Sum(t => t.Pb),
                    Wp = (short)positionLines.Sum(t => t.Wp),
                    Sb = (short)positionLines.Sum(t => t.Sb),
                    Cs = (short)positionLines.Sum(t => t.Cs),
                };
                PositionSummaries.Add(positionSummary);
            }
            return PositionSummaries;
        }
    }
}
