using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class Person
    {
        public string PlayerId { get; set; } = null!;
        public short? BirthYear { get; set; }
        public short? BirthMonth { get; set; }
        public short? BirthDay { get; set; }
        public string? BirthCountry { get; set; }
        public string? BirthState { get; set; }
        public string? BirthCity { get; set; }
        public short? DeathYear { get; set; }
        public short? DeathMonth { get; set; }
        public short? DeathDay { get; set; }
        public string? DeathCountry { get; set; }
        public string? DeathState { get; set; }
        public string? DeathCity { get; set; }
        public string? NameFirst { get; set; }
        public string? NameLast { get; set; }
        public string? NameGiven { get; set; }
        public short? Weight { get; set; }
        public short? Height { get; set; }
        public string? Bats { get; set; }
        public string? Throws { get; set; }
        public string? Debut { get; set; }
        public string? FinalGame { get; set; }
        public string? RetroId { get; set; }
        public string? BbrefId { get; set; }

        public ICollection<Batting> BattingSeasons { get; set; }
        public ICollection<BattingPost> BattingPostSeasons { get; set; }
        public ICollection<Pitching> PitchingSeasons { get; set; }
        public ICollection<Fielding> FieldingSeasons { get; set; }
    }
}
