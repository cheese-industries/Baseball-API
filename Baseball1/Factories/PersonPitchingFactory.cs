using System.Linq;

namespace Baseball1.Factories
{
    public class PersonPitchingFactory
    {
        public static Dtos.PersonPitchingDto ToDto(Person person)
        {
            var CareerERA = 0.00;
            var CareerH9 = 0.0;
            var CareerHR9 = 0.0;
            var CareerBB9 = 0.0;
            var CareerSO9 = 0.0;
            var TotalIPOuts = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ipouts);
            var CareerPartialInnings = (TotalIPOuts % 3);
            var CareerFullInnings = (TotalIPOuts - CareerPartialInnings) / 3;
            var CareerIP = $"{CareerFullInnings.ToString()}.{CareerPartialInnings.ToString()}";
            var CareerW = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.W);
            var CareerL = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.L);
            var CareerWPct = 0.000;
            var CareerBFP = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Bfp);
            var CareerBB = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Bb);
            var CareerHBP = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Hbp);
            var CareerSH = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Sh);
            var CareerSF = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Sf);
            var CareerH = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.H);
            var CareerOppAB = CareerBFP - (CareerBB ?? 0) - (CareerHBP ?? 0) - (CareerSH ?? 0) - (CareerSF ?? 0);
            var CareerOppBA = 0.000;

            if (CareerOppAB > 0)
            {
                CareerOppBA = (double)CareerH / (double)CareerOppAB;
            }

            if (TotalIPOuts > 0)
            {
                CareerERA = (double)((double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Er) * 27
                     / (double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ipouts));
                CareerH9 = (double)((double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.H) * 27
                     / (double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ipouts));
                CareerHR9 = (double)((double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Hr) * 27
                     / (double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ipouts));
                CareerBB9 = (double)((double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Bb) * 27
                     / (double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ipouts));
                CareerSO9 = (double)((double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.So) * 27
                     / (double)person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ipouts));
            }
            
            if (CareerW + CareerL > 0)
            {
                CareerWPct = (double)((double)CareerW / (double)(CareerW + CareerL));
            }

            return new Dtos.PersonPitchingDto
            {
                Name = $"{person.NameFirst} {person.NameLast}",
                PitchingLines = person.PitchingSeasons.Select(b => GetPitchingLine(b)).ToList(),
                TeamSummaries = CreateTeamSummary(person.PitchingSeasons.Select(p => GetPitchingLine(p)).ToList()),
            TotalW = CareerW,
                TotalL = CareerL,
                TotalG = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.G),
                TotalGs = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Gs),
                TotalCg = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Cg),
                TotalSho = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Sho),
                TotalSv = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Sv),
                TotalIpouts = TotalIPOuts,
                TotalIP = CareerIP,
                TotalH = CareerH,
                TotalEr = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Er),
                TotalHr = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Hr),
                TotalBb = CareerBB,
                TotalSo = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.So),
                TotalIbb = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Ibb),
                TotalWp = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Wp),
                TotalHbp = CareerHBP,
                TotalBk = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Bk),
                TotalBfp = CareerBFP,
                TotalGf = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Gf),
                TotalR = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.R),
                TotalSf = CareerSF,
                TotalSh = CareerSH,
                TotalGidp = person.PitchingSeasons.Select(p => GetPitchingLine(p)).Sum(p => p.Gidp),
                TotalERA = Math.Round(CareerERA, 2),
                TotalH9 = Math.Round(CareerH9, 1),
                TotalHR9 = Math.Round(CareerHR9, 1),
                TotalBB9 = Math.Round(CareerBB9, 1),
                TotalSO9 = Math.Round(CareerSO9, 1),
                TotalWPct = Math.Round(CareerWPct, 3),
                TotalOppBA = Math.Round(CareerOppBA, 3),
            };

        }

        private static Dtos.PitchingDto GetPitchingLine(Pitching pitching)
        {
            var OppAB = pitching.Bfp - pitching.Bb;
                //- pitching.Hbp - pitching.Sh - pitching.Sf;
            var Hits = pitching.H;
            decimal OppBA = 0;
            if (OppAB > 0) { 
                OppBA = (decimal)Hits / (decimal)OppAB;
            }
       
            var PartialIP = pitching.Ipouts % 3;
            var FullIP = (pitching.Ipouts - PartialIP) / 3;
            var IP = $"{FullIP}.{PartialIP}";
            var WPct = .000;
            if(pitching.W + pitching.L > 0)
            {
                WPct = (double)pitching.W / (double)(pitching.W + pitching.L);
            }
            var ERA = 0.00;
            var H9 = 0.0;
            var BB9 = 0.0;
            var HR9 = 0.0;
            var SO9 = 0.0;
            if (pitching.Ipouts > 0)
            {
                ERA = (double)pitching.Er * 27 / (double)pitching.Ipouts;
                H9 = (double)pitching.H * 27 / (double)pitching.Ipouts;
                BB9 = (double)pitching.Bb * 27 / (double)pitching.Ipouts;
                HR9 = (double)pitching.Hr * 27 / (double)pitching.Ipouts;
                SO9 = (double)pitching.So * 27 / (double)pitching.Ipouts;
            }
            return new Dtos.PitchingDto
            {
                YearId = pitching.YearId,
                TeamId = pitching.TeamId,
                W = pitching.W,
                L = pitching.L,
                G = pitching.G,
                Gs = pitching.Gs,
                Cg = pitching.Cg,
                Sho = pitching.Sho,
                Sv = pitching.Sv,
                Ipouts = pitching.Ipouts,
                Ip = IP,
                H = pitching.H,
                Er = pitching.Er,
                Hr = pitching.Hr,
                Bb = pitching.Bb,
                So = pitching.So,
                Ibb = pitching.Ibb,
                Wp = pitching.Wp,
                Hbp = pitching.Hbp,
                Bk = pitching.Bk,
                Bfp = pitching.Bfp,
                Gf = pitching.Gf,
                R = pitching.R,
                Sf = pitching.Sf,
                Sh = pitching.Sh,
                Gidp = pitching.Gidp,
                WPct = Math.Round(WPct,3),
                Oppba = OppBA,
                era = Math.Round(ERA,2),
                h9 = Math.Round(H9,1),
                hr9 = Math.Round(HR9,1),
                bb9 = Math.Round(BB9,1),
                so9 = Math.Round(SO9,1),
            };
        }

        private static List<Dtos.TeamPitchingSummaryDto> CreateTeamSummary(List<Dtos.PitchingDto> pitchingLines)
        {
            var TeamSummaries = new List<Dtos.TeamPitchingSummaryDto>();
            var UniqueTeams = pitchingLines.Select(t => t.TeamId).Distinct();
            foreach (var team in UniqueTeams)
            {
                var TeamERA = 0.00;
                var TeamH9 = 0.0;
                var TeamHR9 = 0.0;
                var TeamBB9 = 0.0;
                var TeamSO9 = 0.0;
                var teamPitchingLines = pitchingLines.Where(t => t.TeamId == team);
                var TeamH = teamPitchingLines.Sum(t => t.H);
                var TeamEr = teamPitchingLines.Sum(t => t.Er);
                var TeamHr = teamPitchingLines.Sum(t => t.Hr);
                var TeamBb = teamPitchingLines.Sum(t => t.Bb);
                var TeamSo = teamPitchingLines.Sum(t => t.So);
                var Ipouts = teamPitchingLines.Sum(t => t.Ipouts);
                var TeamHbp = teamPitchingLines.Sum(t => t.Hbp);
                var TeamBfp = teamPitchingLines.Sum(t => t.Bfp);
                var TeamSh = teamPitchingLines.Sum(t => t.Sh);
                var TeamSf = teamPitchingLines.Sum(t => t.Sf);
          
                var TeamOppAB = TeamBfp - (TeamBb ?? 0) - (TeamHbp ?? 0) - (TeamSh ?? 0) - (TeamSf ?? 0);
                var TeamOppBA = (decimal)0.000;

                if (TeamOppAB > 0)
                {
                    TeamOppBA = (decimal)TeamH / (decimal)TeamOppAB;
                }

                if (Ipouts > 0)
                {
                    TeamERA = (double)TeamEr * 27 / (double)Ipouts;
                    TeamH9 = (double)TeamH * 27 / (double)Ipouts;
                    TeamBB9 = (double)TeamBb * 27 / (double)Ipouts;
                    TeamHR9 = (double)TeamHr * 27 / (double)Ipouts;
                    TeamSO9 = (double)TeamSo * 27 / (double)Ipouts;
                }
                var TeamPartialInnings = (Ipouts % 3);
                var TeamFullInnings = (Ipouts - TeamPartialInnings) / 3;
                var TeamIP = $"{TeamFullInnings.ToString()}.{TeamPartialInnings.ToString()}";
                var TeamW = (short)teamPitchingLines.Sum(t => t.W);
                var TeamL = (short)teamPitchingLines.Sum(t => t.L);
                var TeamWPct = 0.000;
                if (TeamW + TeamL > 0)
                {
                    TeamWPct = (double)((double)TeamW / (double)(TeamW + TeamL));
                }
                var teamSummary = new Dtos.TeamPitchingSummaryDto
                {
                    TeamId = team,
                    W = (short)teamPitchingLines.Sum(t => t.W),
                    L = (short)teamPitchingLines.Sum(t => t.L),
                    G = (short)teamPitchingLines.Sum(t => t.G),
                    Gs = (short)teamPitchingLines.Sum(t => t.Gs),
                    Cg = (short)teamPitchingLines.Sum(t => t.Cg),
                    Sho = (short)teamPitchingLines.Sum(t => t.Sho),
                    Sv = (short)teamPitchingLines.Sum(t => t.Sv),
                    //Ipouts = (short)teamPitchingLines.Sum(t => t.Ipouts),
                    WPct = Math.Round(TeamWPct,3),
                    era = Math.Round(TeamERA,2),
                    h9 = Math.Round(TeamH9,1),
                    hr9 = Math.Round(TeamHR9, 1),
                    bb9 = Math.Round(TeamBB9, 1),
                    so9 = Math.Round(TeamSO9, 1),
                    Oppba = (decimal)Math.Round(TeamOppBA,3),
                    Ip = TeamIP,
                    H = (short)teamPitchingLines.Sum(t => t.H),
                    Er = (short)teamPitchingLines.Sum(t => t.Er),
                    Hr = (short)teamPitchingLines.Sum(t => t.Hr),
                    Bb = (short)teamPitchingLines.Sum(t => t.Bb),
                    So = (short)teamPitchingLines.Sum(t => t.So),
                    Ibb = (short)teamPitchingLines.Sum(t => t.Ibb),
                    Wp = (short)teamPitchingLines.Sum(t => t.Wp),
                    Hbp = (short)teamPitchingLines.Sum(t => t.Hbp),
                    Bk = (short)teamPitchingLines.Sum(t => t.Bk),
                    Bfp = (short)teamPitchingLines.Sum(t => t.Bfp),
                    Gf = (short)teamPitchingLines.Sum(t => t.Gf),
                    R = (short)teamPitchingLines.Sum(t => t.R),
                    Sf = (short)teamPitchingLines.Sum(t => t.Sf),
                    Sh = (short)teamPitchingLines.Sum(t => t.Sh),
                    Gidp = (short)teamPitchingLines.Sum(t => t.Gidp),
                };
                TeamSummaries.Add(teamSummary);
            }
                return TeamSummaries;
        }
    }
}
