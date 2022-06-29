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
            var CareerOppAB = CareerBFP - CareerBB - CareerHBP - CareerSH - CareerSF;
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
    }
}
