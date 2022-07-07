using System.Linq;

namespace Baseball1.Factories
{
    public static class PersonBattingFactory
    {

        public static Dtos.PersonBattingDto ToDto(Person person)
        {
            var BatLineShortcut = person.BattingSeasons.Select(b => GetBattingLine(b));
            

            //var BirthMonth = person.BirthMonth switch { 
            //    1 => "January", 
            //    2 => "February",
            //    //...
            //    _ => " " };

            var CareerPA = BatLineShortcut.Sum(b => b.Ab) +
                BatLineShortcut.Sum(b => b.Bb) +
                BatLineShortcut.Sum(b => b.Sh) +
                BatLineShortcut.Sum(b => b.Sf) +
                BatLineShortcut.Sum(b => b.Hbp);

            var CareerTB = BatLineShortcut.Sum(b => b.H) +
                BatLineShortcut.Sum(b => b._2b) +
                2 * BatLineShortcut.Sum(b => b._3b) +
                3 * BatLineShortcut.Sum(b => b.Hr);

            var CareerBA = 0.0000;
            var CareerOBP = 0.00000;
            var CareerSLG = 0.00000;

            var isDeceased = false;

            if (CareerPA == 0)
            {
                CareerBA = 0;
                CareerOBP = 0;
                CareerSLG = 0;
            }

            else if (CareerPA != 0 && BatLineShortcut.Sum(b => b.Ab) == 0)
            {
                CareerBA = 0;
                CareerSLG = 0;
                CareerOBP =
                    Math.Round((float)
                        (BatLineShortcut.Sum(b => b.Bb) +
                        BatLineShortcut.Sum(b => b.H) +
                        BatLineShortcut.Sum(b => b.Hbp)) /
                        CareerPA, 3);
            }
            else
            {
                CareerBA = Math.Round((float)BatLineShortcut.Sum(b => b.H)
                    / (float)(BatLineShortcut.Sum(b => b.Ab)), 3);

                CareerOBP =
                    Math.Round((float)
                        (BatLineShortcut.Sum(b => b.Bb) +
                        BatLineShortcut.Sum(b => b.H) +
                        BatLineShortcut.Sum(b => b.Hbp)) /
                        CareerPA, 3);

                CareerSLG = Math.Round((float)CareerTB / (float)(BatLineShortcut.Sum(b => b.Ab)), 3);
            }

            var deathCity = "";
            var deathState = "";
            var deathCountry = "";
            var deathYear = person.DeathYear;
            var deathMonth = person.DeathMonth;
            var deathDay = person.DeathDay;
            var deathDateTime = new DateTime(1, 1, 1);
            

            if(person.DeathCity?.Length > 0 || person.DeathState?.Length > 0 || person.DeathCountry?.Length > 0)
            {
                deathCity = $"{person.DeathCity}";
                deathState = $"{person.DeathState}";
                deathCountry = $"{person.DeathCountry}";
                isDeceased = true;
                deathDateTime = new DateTime((int)deathYear, (int)deathMonth, (int)deathDay);
            }

            return new Dtos.PersonBattingDto
            {
                Name = $"{person.NameFirst} {person.NameLast}",
                FullName = $"{person.NameGiven} {person.NameLast}",
                BirthDateTime = new DateTime((int)person.BirthYear, (int)person.BirthMonth, (int)person.BirthDay),
                BirthCity = $"{person.BirthCity}",
                BirthState = $"{person.BirthState}",
                BirthCountry = $"{person.BirthCountry}",
                DeathDateTime = deathDateTime,
                DeathCity = deathCity,
                DeathState = deathState,
                DeathCountry = deathCountry,
                IsDeceased = isDeceased,
                Bats = person.Bats,
                Throws = person.Throws,
                BattingLines = BatLineShortcut.ToList(),
                TotalG = BatLineShortcut.Sum(b => b.G),
                TotalAB = BatLineShortcut.Sum(b => b.Ab),
                TotalR = BatLineShortcut.Sum(b => b.R),
                TotalH = BatLineShortcut.Sum(b => b.H),
                TotalRBI = BatLineShortcut.Sum(b => b.Rbi),
                Total2B = BatLineShortcut.Sum(b => b._2b),
                Total3B = BatLineShortcut.Sum(b => b._3b),
                TotalHR = BatLineShortcut.Sum(b => b.Hr),
                TotalBB = BatLineShortcut.Sum(b => b.Bb),
                TotalSO = BatLineShortcut.Sum(b => b.So),
                TotalSB = BatLineShortcut.Sum(b => b.Sb),
                TotalCS = BatLineShortcut.Sum(b => b.Cs),
                TotalHBP = BatLineShortcut.Sum(b => b.Hbp),
                TotalIBB = BatLineShortcut.Sum(b => b.Ibb),
                TotalGIDP = BatLineShortcut.Sum(b => b.Gidp),
                TotalSH = BatLineShortcut.Sum(b => b.Sh),
                TotalSF = BatLineShortcut.Sum(b => b.Sf),
                CareerBA = (float)CareerBA,
                CareerOBP = (float)CareerOBP,
                CareerSLG = (float)CareerSLG,
                TeamSummaries = CreateTeamSummary(BatLineShortcut.ToList()),
            };
        }
        private static Dtos.BattingDto GetBattingLine(Batting batting)
        {

            if (batting.Ab + batting.Bb + batting.Sh + batting.Sf + batting.Hbp == null || batting.Ab + batting.Bb + batting.Sh + batting.Sf + batting.Hbp == 0)
            {
                return new Dtos.BattingDto
                {
                    YearId = batting.YearId,
                    TeamId = batting.TeamId,
                    G = batting.G,
                    Ab = batting.Ab,
                    R = batting.R,
                    H = batting.H,
                    _2b = batting._2b,
                    _3b = batting._3b,
                    Hr = batting.Hr,
                    Rbi = batting.Rbi,
                    Sb = batting.Sb,
                    Cs = batting.Cs,
                    Bb = batting.Bb,
                    So = batting.So,
                    Ibb = batting.Ibb,
                    Hbp = batting.Hbp,
                    Sh = batting.Sh,
                    Sf = batting.Sf,
                    Gidp = batting.Gidp,
                    BA = 0,
                    OBP = 0,
                    SLG = 0
                };
            }
            else if (batting.Ab == null || batting.Ab == 0)
            {
                return new Dtos.BattingDto
                {
                    YearId = batting.YearId,
                    TeamId = batting.TeamId,
                    G = batting.G,
                    Ab = batting.Ab,
                    R = batting.R,
                    H = batting.H,
                    _2b = batting._2b,
                    _3b = batting._3b,
                    Hr = batting.Hr,
                    Rbi = batting.Rbi,
                    Sb = batting.Sb,
                    Cs = batting.Cs,
                    Bb = batting.Bb,
                    So = batting.So,
                    Ibb = batting.Ibb,
                    Hbp = batting.Hbp,
                    Sh = batting.Sh,
                    Sf = batting.Sf,
                    Gidp = batting.Gidp,
                    BA = 0,
                    OBP = Math.Round((float)(batting.H + batting.Bb + batting.Hbp) / (batting.Ab + batting.Bb + batting.Hbp + batting.Sf), 3),
                    SLG = 0
                };
            }

            else return new Dtos.BattingDto
            {
                YearId = batting.YearId,
                TeamId = batting.TeamId,
                G = batting.G,
                Ab = batting.Ab,
                R = batting.R,
                H = batting.H,
                _2b = batting._2b,
                _3b = batting._3b,
                Hr = batting.Hr,
                Rbi = batting.Rbi,
                Sb = batting.Sb,
                Cs = batting.Cs,
                Bb = batting.Bb,
                So = batting.So,
                Ibb = batting.Ibb,
                Hbp = batting.Hbp,
                Sh = batting.Sh,
                Sf = batting.Sf,
                Gidp = batting.Gidp,
                BA = Math.Round((float)(batting.H) / (float)(batting.Ab), 3),
                OBP = Math.Round((float)(batting.H + batting.Bb + batting.Hbp) / (batting.Ab + batting.Bb + batting.Hbp + batting.Sf), 3),
                SLG = Math.Round((float)(batting.H + batting._2b + (2 * batting._3b) + (3 * batting.Hr)) / (batting.Ab), 3)

            };
        }
        private static List<Dtos.TeamBattingSummaryDto> CreateTeamSummary(List<Dtos.BattingDto> battingLines)
        {
            var TeamSummaries = new List<Dtos.TeamBattingSummaryDto>();
            // Get unique values for batting.TeamId
            var UniqueTeams = battingLines.Select(t => t.TeamId).Distinct();
            // Create list for each unique value
            // for each line, assign to correct list
            foreach (var team in UniqueTeams)
            {
                //Take batting lines where teamId == team
                var teamBattingLines = battingLines.Where(t => t.TeamId == team);
                var TeamBa = .000;
                var TeamObp = .000;
                var TeamSlg = .000;
                var TeamAb = teamBattingLines.Sum(t => t.Ab);
                var TeamH = teamBattingLines.Sum(t => t.H);
                var TeamBb = teamBattingLines.Sum(t => t.Bb);
                var TeamHbp = teamBattingLines.Sum(t => t.Hbp);
                var TeamSf = teamBattingLines.Sum(t => t.Sf);
                var Team2b = teamBattingLines.Sum(t => t._2b);
                var Team3b = teamBattingLines.Sum(t => t._3b);
                var TeamHr = teamBattingLines.Sum(t => t.Hr);
                var TeamTb = TeamH + Team2b + 2*Team3b + 3*TeamHr;
                var TeamPa = TeamAb + TeamBb + TeamHbp + TeamSf;
                if (TeamAb != null && TeamAb !=0)
                {
                    TeamBa = Math.Round((float)(TeamH) / (float)(TeamAb), 3);
                    TeamSlg = Math.Round((float)(TeamTb) / (float)(TeamAb), 3);
                }
                if (TeamPa != null && TeamPa !=0)
                {
                    TeamObp = Math.Round(((float)(TeamH) + (float)(TeamHbp) + (float)(TeamBb)) / (float)(TeamPa), 3);
                }

                var teamSummary = new Dtos.TeamBattingSummaryDto
              {
                    TeamId = team,
                    G = (short)teamBattingLines.Sum(t => t.G),
                    Ab = (short)teamBattingLines.Sum(t => t.Ab),
                    R = (short)teamBattingLines.Sum(t => t.R),
                    H = (short)teamBattingLines.Sum(t => t.H),
                    _2b = (short)teamBattingLines.Sum(t => t._2b),
                    _3b = (short)teamBattingLines.Sum(t => t._3b),
                    Hr = (short)teamBattingLines.Sum(t => t.Hr),
                    Rbi = (short)teamBattingLines.Sum(t => t.Rbi),
                    Sb = (short)teamBattingLines.Sum(t => t.Sb),
                    Cs = (short)teamBattingLines.Sum(t => t.Cs),
                    Bb = (short)teamBattingLines.Sum(t => t.Bb),
                    So = (short)teamBattingLines.Sum(t => t.So),
                    Ibb = (short)teamBattingLines.Sum(t => t.Ibb),
                    Hbp = (short)teamBattingLines.Sum(t => t.Hbp),
                    Sh = (short)teamBattingLines.Sum(t => t.Sh),
                    Sf = (short)teamBattingLines.Sum(t => t.Sf),
                    Gidp = (short)teamBattingLines.Sum(t => t.Gidp),
                    BA = TeamBa,
                    OBP = TeamObp,
                    SLG = TeamSlg,
                };
                TeamSummaries.Add(teamSummary);
            }
                return TeamSummaries;
        }
    }
}
