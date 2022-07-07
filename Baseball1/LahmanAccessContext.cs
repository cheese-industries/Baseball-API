using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Baseball1
{
    public partial class LahmanAccessContext : DbContext
    {
        public LahmanAccessContext()
        {
        }

        public LahmanAccessContext(DbContextOptions<LahmanAccessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllstarFull> AllstarFulls { get; set; } = null!;
        public virtual DbSet<Appearance> Appearances { get; set; } = null!;
        public virtual DbSet<AwardsManager> AwardsManagers { get; set; } = null!;
        public virtual DbSet<AwardsPlayer> AwardsPlayers { get; set; } = null!;
        public virtual DbSet<AwardsShareManager> AwardsShareManagers { get; set; } = null!;
        public virtual DbSet<AwardsSharePlayer> AwardsSharePlayers { get; set; } = null!;
        public virtual DbSet<Batting> Battings { get; set; } = null!;
        public virtual DbSet<BattingPost> BattingPosts { get; set; } = null!;
        public virtual DbSet<CollegePlaying> CollegePlayings { get; set; } = null!;
        public virtual DbSet<Fielding> Fieldings { get; set; } = null!;
        public virtual DbSet<FieldingOf> FieldingOfs { get; set; } = null!;
        public virtual DbSet<FieldingOfsplit> FieldingOfsplits { get; set; } = null!;
        public virtual DbSet<FieldingPost> FieldingPosts { get; set; } = null!;
        public virtual DbSet<HallOfFame> HallOfFames { get; set; } = null!;
        public virtual DbSet<HomeGame> HomeGames { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<ManagersHalf> ManagersHalves { get; set; } = null!;
        public virtual DbSet<Park> Parks { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Pitching> Pitchings { get; set; } = null!;
        public virtual DbSet<PitchingPost> PitchingPosts { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<SeriesPost> SeriesPosts { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamsFranchise> TeamsFranchises { get; set; } = null!;
        public virtual DbSet<TeamsHalf> TeamsHalves { get; set; } = null!;
        public virtual DbSet<War> Wars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=LahmanAccess;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllstarFull>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AllstarFull");

                entity.HasIndex(e => e.GameId, "AllstarFull$gameID");

                entity.HasIndex(e => e.GameNum, "AllstarFull$gameNum");

                entity.HasIndex(e => e.LgId, "AllstarFull$lgID");

                entity.HasIndex(e => e.PlayerId, "AllstarFull$playerID");

                entity.HasIndex(e => e.TeamId, "AllstarFull$teamID");

                entity.HasIndex(e => e.YearId, "AllstarFull$yearID");

                entity.Property(e => e.GameId)
                    .HasMaxLength(255)
                    .HasColumnName("gameID");

                entity.Property(e => e.GameNum).HasColumnName("gameNum");

                entity.Property(e => e.Gp).HasColumnName("GP");

                entity.Property(e => e.LgId)
                    .HasMaxLength(255)
                    .HasColumnName("lgID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(255)
                    .HasColumnName("playerID");

                entity.Property(e => e.StartingPos)
                    .HasMaxLength(255)
                    .HasColumnName("startingPos");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(255)
                    .HasColumnName("teamID");

                entity.Property(e => e.YearId).HasColumnName("yearID");
            });

            modelBuilder.Entity<Appearance>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId })
                    .HasName("Appearances$Index_70924BF9_C76C_4076");

                entity.HasIndex(e => e.LgId, "Appearances$lgID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.G1b).HasColumnName("G_1b");

                entity.Property(e => e.G2b).HasColumnName("G_2b");

                entity.Property(e => e.G3b).HasColumnName("G_3b");

                entity.Property(e => e.GAll).HasColumnName("G_all");

                entity.Property(e => e.GBatting).HasColumnName("G_batting");

                entity.Property(e => e.GC).HasColumnName("G_c");

                entity.Property(e => e.GCf).HasColumnName("G_cf");

                entity.Property(e => e.GDefense).HasColumnName("G_defense");

                entity.Property(e => e.GDh).HasColumnName("G_dh");

                entity.Property(e => e.GLf).HasColumnName("G_lf");

                entity.Property(e => e.GOf).HasColumnName("G_of");

                entity.Property(e => e.GP).HasColumnName("G_p");

                entity.Property(e => e.GPh).HasColumnName("G_ph");

                entity.Property(e => e.GPr).HasColumnName("G_pr");

                entity.Property(e => e.GRf).HasColumnName("G_rf");

                entity.Property(e => e.GSs).HasColumnName("G_ss");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");
                entity.HasOne(e => e.Person).WithMany(v => v.AppearanceSeasons);
            });

            modelBuilder.Entity<AwardsManager>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.AwardId, e.LgId, e.PlayerId })
                    .HasName("AwardsManagers$Index_5B79AD08_A7C1_426E");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.AwardId)
                    .HasMaxLength(75)
                    .HasColumnName("awardID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .HasColumnName("notes");

                entity.Property(e => e.Tie)
                    .HasMaxLength(1)
                    .HasColumnName("tie");
            });

            modelBuilder.Entity<AwardsPlayer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AwardId)
                    .HasMaxLength(255)
                    .HasColumnName("awardID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(255)
                    .HasColumnName("lgID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(255)
                    .HasColumnName("playerID");

                entity.Property(e => e.Tie)
                    .HasMaxLength(255)
                    .HasColumnName("tie");

                entity.Property(e => e.YearId).HasColumnName("yearID");
            });

            modelBuilder.Entity<AwardsShareManager>(entity =>
            {
                entity.HasKey(e => new { e.AwardId, e.YearId, e.LgId, e.PlayerId })
                    .HasName("AwardsShareManagers$Index_4D947987_0BEF_4B9B");

                entity.Property(e => e.AwardId)
                    .HasMaxLength(25)
                    .HasColumnName("awardID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.PointsMax).HasColumnName("pointsMax");

                entity.Property(e => e.PointsWon).HasColumnName("pointsWon");

                entity.Property(e => e.VotesFirst).HasColumnName("votesFirst");
            });

            modelBuilder.Entity<AwardsSharePlayer>(entity =>
            {
                entity.HasKey(e => new { e.AwardId, e.YearId, e.LgId, e.PlayerId })
                    .HasName("AwardsSharePlayers$Index_020E6DB1_95E2_44F1");

                entity.Property(e => e.AwardId)
                    .HasMaxLength(25)
                    .HasColumnName("awardID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.PointsMax).HasColumnName("pointsMax");

                entity.Property(e => e.PointsWon).HasColumnName("pointsWon");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.VotesFirst).HasColumnName("votesFirst");
            });

            modelBuilder.Entity<Batting>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint })
                    .HasName("Batting$Index_7170BE9D_268A_46B8");

                entity.ToTable("Batting");

                entity.HasIndex(e => e.LgId, "Batting$lgID");

                entity.HasIndex(e => e.TeamId, "Batting$teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.GBatting).HasColumnName("G_batting");

                entity.Property(e => e.GOld).HasColumnName("G_old");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Rbi).HasColumnName("RBI");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e._2b).HasColumnName("2B");

                entity.Property(e => e._3b).HasColumnName("3B");
                entity.HasOne(e => e.Person).WithMany(v => v.BattingSeasons);
            });

            modelBuilder.Entity<BattingPost>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.Round, e.PlayerId })
                    .HasName("BattingPost$Index_8C81D106_6E96_4318");

                entity.ToTable("BattingPost");

                entity.HasIndex(e => e.LgId, "BattingPost$lgID");

                entity.HasIndex(e => e.TeamId, "BattingPost$teamID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasMaxLength(10)
                    .HasColumnName("round");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Rbi).HasColumnName("RBI");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e._2b).HasColumnName("2B");

                entity.Property(e => e._3b).HasColumnName("3B");
            });

            modelBuilder.Entity<CollegePlaying>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CollegePlaying");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.SchoolId)
                    .HasMaxLength(15)
                    .HasColumnName("schoolID");

                entity.Property(e => e.YearId).HasColumnName("yearID");
            });

            modelBuilder.Entity<Fielding>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.Pos })
                    .HasName("Fielding$Index_97751AED_0076_4367");

                entity.ToTable("Fielding");

                entity.HasIndex(e => e.LgId, "Fielding$lgID");

                entity.HasIndex(e => e.TeamId, "Fielding$teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Pos)
                    .HasMaxLength(2)
                    .HasColumnName("POS");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.Po).HasColumnName("PO");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Wp).HasColumnName("WP");

                entity.Property(e => e.Zr).HasColumnName("ZR");
            });

            modelBuilder.Entity<FieldingOf>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint })
                    .HasName("FieldingOF$Index_8983CB74_6371_424E");

                entity.ToTable("FieldingOF");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");
            });

            modelBuilder.Entity<FieldingOfsplit>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.Pos })
                    .HasName("FieldingOFsplit$Index_97751AED_0076_4367");

                entity.ToTable("FieldingOFsplit");

                entity.HasIndex(e => e.LgId, "FieldingOFsplit$lgID");

                entity.HasIndex(e => e.TeamId, "FieldingOFsplit$teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Pos)
                    .HasMaxLength(2)
                    .HasColumnName("POS");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.Po).HasColumnName("PO");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Wp).HasColumnName("WP");

                entity.Property(e => e.Zr).HasColumnName("ZR");
            });

            modelBuilder.Entity<FieldingPost>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Round, e.Pos })
                    .HasName("FieldingPost$Index_E1DA201A_3B38_486D");

                entity.ToTable("FieldingPost");

                entity.HasIndex(e => e.LgId, "FieldingPost$lgID");

                entity.HasIndex(e => e.TeamId, "FieldingPost$teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasMaxLength(10)
                    .HasColumnName("round");

                entity.Property(e => e.Pos)
                    .HasMaxLength(2)
                    .HasColumnName("POS");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.Po).HasColumnName("PO");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Tp).HasColumnName("TP");
            });

            modelBuilder.Entity<HallOfFame>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.Yearid, e.VotedBy })
                    .HasName("HallOfFame$PrimaryKey");

                entity.ToTable("HallOfFame");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.Property(e => e.VotedBy)
                    .HasMaxLength(64)
                    .HasColumnName("votedBy");

                entity.Property(e => e.Ballots).HasColumnName("ballots");

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .HasColumnName("category");

                entity.Property(e => e.Inducted)
                    .HasMaxLength(1)
                    .HasColumnName("inducted");

                entity.Property(e => e.Needed).HasColumnName("needed");

                entity.Property(e => e.NeededNote)
                    .HasMaxLength(25)
                    .HasColumnName("needed_note");

                entity.Property(e => e.Votes).HasColumnName("votes");
            });

            modelBuilder.Entity<HomeGame>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Leaguekey, "HomeGames$leaguekey");

                entity.HasIndex(e => e.Parkkey, "HomeGames$parkkey");

                entity.HasIndex(e => e.Teamkey, "HomeGames$teamkey");

                entity.HasIndex(e => e.Yearkey, "HomeGames$yearkey");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Games).HasColumnName("games");

                entity.Property(e => e.Leaguekey)
                    .HasMaxLength(255)
                    .HasColumnName("leaguekey");

                entity.Property(e => e.Openings).HasColumnName("openings");

                entity.Property(e => e.Parkkey)
                    .HasMaxLength(255)
                    .HasColumnName("parkkey");

                entity.Property(e => e.Spanfirst)
                    .HasMaxLength(255)
                    .HasColumnName("spanfirst");

                entity.Property(e => e.Spanlast)
                    .HasMaxLength(255)
                    .HasColumnName("spanlast");

                entity.Property(e => e.Teamkey)
                    .HasMaxLength(255)
                    .HasColumnName("teamkey");

                entity.Property(e => e.Yearkey).HasColumnName("yearkey");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.Inseason })
                    .HasName("Managers$Index_836DE8E8_FEBD_469A");

                entity.HasIndex(e => e.LgId, "Managers$lgID");

                entity.HasIndex(e => e.PlayerId, "Managers$managerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Inseason).HasColumnName("inseason");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.PlyrMgr)
                    .HasMaxLength(1)
                    .HasColumnName("plyrMgr");

                entity.Property(e => e.Rank).HasColumnName("rank");
            });

            modelBuilder.Entity<ManagersHalf>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId, e.Half })
                    .HasName("ManagersHalf$Index_C2906EEF_9F52_4968");

                entity.ToTable("ManagersHalf");

                entity.HasIndex(e => e.LgId, "ManagersHalf$lgID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.Half).HasColumnName("half");

                entity.Property(e => e.Inseason).HasColumnName("inseason");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Rank).HasColumnName("rank");
            });

            modelBuilder.Entity<Park>(entity =>
            {
                entity.HasIndex(e => e.Parkkey, "Parks$parkkey");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Parkalias)
                    .HasMaxLength(255)
                    .HasColumnName("parkalias");

                entity.Property(e => e.Parkkey)
                    .HasMaxLength(255)
                    .HasColumnName("parkkey");

                entity.Property(e => e.Parkname)
                    .HasMaxLength(255)
                    .HasColumnName("parkname");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("People$playerID");

                entity.HasIndex(e => e.BbrefId, "People$bbrefID");

                entity.HasIndex(e => e.RetroId, "People$retroID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(255)
                    .HasColumnName("playerID");

                entity.Property(e => e.Bats)
                    .HasMaxLength(255)
                    .HasColumnName("bats");

                entity.Property(e => e.BbrefId)
                    .HasMaxLength(255)
                    .HasColumnName("bbrefID");

                entity.Property(e => e.BirthCity)
                    .HasMaxLength(255)
                    .HasColumnName("birthCity");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(255)
                    .HasColumnName("birthCountry");

                entity.Property(e => e.BirthDay).HasColumnName("birthDay");

                entity.Property(e => e.BirthMonth).HasColumnName("birthMonth");

                entity.Property(e => e.BirthState)
                    .HasMaxLength(255)
                    .HasColumnName("birthState");

                entity.Property(e => e.BirthYear).HasColumnName("birthYear");

                entity.Property(e => e.DeathCity)
                    .HasMaxLength(255)
                    .HasColumnName("deathCity");

                entity.Property(e => e.DeathCountry)
                    .HasMaxLength(255)
                    .HasColumnName("deathCountry");

                entity.Property(e => e.DeathDay).HasColumnName("deathDay");

                entity.Property(e => e.DeathMonth).HasColumnName("deathMonth");

                entity.Property(e => e.DeathState)
                    .HasMaxLength(255)
                    .HasColumnName("deathState");

                entity.Property(e => e.DeathYear).HasColumnName("deathYear");

                entity.Property(e => e.Debut)
                    .HasMaxLength(255)
                    .HasColumnName("debut");

                entity.Property(e => e.FinalGame)
                    .HasMaxLength(255)
                    .HasColumnName("finalGame");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.NameFirst)
                    .HasMaxLength(255)
                    .HasColumnName("nameFirst");

                entity.Property(e => e.NameGiven)
                    .HasMaxLength(255)
                    .HasColumnName("nameGiven");

                entity.Property(e => e.NameLast)
                    .HasMaxLength(255)
                    .HasColumnName("nameLast");

                entity.Property(e => e.RetroId)
                    .HasMaxLength(255)
                    .HasColumnName("retroID");

                entity.Property(e => e.Throws)
                    .HasMaxLength(255)
                    .HasColumnName("throws");

                entity.Property(e => e.Weight).HasColumnName("weight");
                entity.HasMany(v => v.BattingSeasons).WithOne(v => v.Person);

                entity.HasMany(v => v.BattingPostSeasons).WithOne(v => v.Person);

                entity.HasMany(v => v.PitchingSeasons).WithOne(v => v.Person);

                entity.HasMany(v => v.AppearanceSeasons).WithOne(v => v.Person);
            });

            modelBuilder.Entity<Pitching>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint })
                    .HasName("Pitching$Index_481778A5_18F2_430E");

                entity.ToTable("Pitching");

                entity.HasIndex(e => e.LgId, "Pitching$lgID");

                entity.HasIndex(e => e.TeamId, "Pitching$teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.Baopp).HasColumnName("BAOpp");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bfp).HasColumnName("BFP");

                entity.Property(e => e.Bk).HasColumnName("BK");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Gf).HasColumnName("GF");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Wp).HasColumnName("WP");
                entity.HasOne(e => e.Person).WithMany(v => v.PitchingSeasons);
            });

            modelBuilder.Entity<PitchingPost>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Round })
                    .HasName("PitchingPost$Index_E71336E6_AB00_432C");

                entity.ToTable("PitchingPost");

                entity.HasIndex(e => e.LgId, "PitchingPost$lgID");

                entity.HasIndex(e => e.TeamId, "PitchingPost$teamID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasMaxLength(10)
                    .HasColumnName("round");

                entity.Property(e => e.Baopp).HasColumnName("BAOpp");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bfp).HasColumnName("BFP");

                entity.Property(e => e.Bk).HasColumnName("BK");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Gf).HasColumnName("GF");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Wp).HasColumnName("WP");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.LgId, e.PlayerId })
                    .HasName("Salaries$Index_E5568031_00FA_49CA");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(9)
                    .HasColumnName("playerID");

                entity.Property(e => e.Salary1).HasColumnName("salary");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.SchoolId)
                    .HasMaxLength(15)
                    .HasColumnName("schoolID");

                entity.Property(e => e.City)
                    .HasMaxLength(55)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(55)
                    .HasColumnName("country");

                entity.Property(e => e.NameFull)
                    .HasMaxLength(255)
                    .HasColumnName("name_full");

                entity.Property(e => e.State)
                    .HasMaxLength(55)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<SeriesPost>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.Round })
                    .HasName("SeriesPost$Index_4F4214D5_9891_4F3C");

                entity.ToTable("SeriesPost");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Round)
                    .HasMaxLength(5)
                    .HasColumnName("round");

                entity.Property(e => e.LgIdloser)
                    .HasMaxLength(2)
                    .HasColumnName("lgIDloser");

                entity.Property(e => e.LgIdwinner)
                    .HasMaxLength(2)
                    .HasColumnName("lgIDwinner");

                entity.Property(e => e.Losses).HasColumnName("losses");

                entity.Property(e => e.TeamIdloser)
                    .HasMaxLength(3)
                    .HasColumnName("teamIDloser");

                entity.Property(e => e.TeamIdwinner)
                    .HasMaxLength(3)
                    .HasColumnName("teamIDwinner");

                entity.Property(e => e.Ties).HasColumnName("ties");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.LgId, e.TeamId })
                    .HasName("Teams$Index_285058F1_D841_4142");

                entity.HasIndex(e => e.DivId, "Teams$divID");

                entity.HasIndex(e => e.FranchId, "Teams$franchID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bba).HasColumnName("BBA");

                entity.Property(e => e.Bpf).HasColumnName("BPF");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.DivId)
                    .HasMaxLength(1)
                    .HasColumnName("divID");

                entity.Property(e => e.DivWin).HasMaxLength(1);

                entity.Property(e => e.Dp).HasColumnName("DP");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Fp).HasColumnName("FP");

                entity.Property(e => e.FranchId)
                    .HasMaxLength(3)
                    .HasColumnName("franchID");

                entity.Property(e => e.Ha).HasColumnName("HA");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Hra).HasColumnName("HRA");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LgWin).HasMaxLength(1);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Park)
                    .HasMaxLength(255)
                    .HasColumnName("park");

                entity.Property(e => e.Ppf).HasColumnName("PPF");

                entity.Property(e => e.Ra).HasColumnName("RA");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Soa).HasColumnName("SOA");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.TeamIdbr)
                    .HasMaxLength(3)
                    .HasColumnName("teamIDBR");

                entity.Property(e => e.TeamIdlahman45)
                    .HasMaxLength(3)
                    .HasColumnName("teamIDlahman45");

                entity.Property(e => e.TeamIdretro)
                    .HasMaxLength(3)
                    .HasColumnName("teamIDretro");

                entity.Property(e => e.Wcwin)
                    .HasMaxLength(1)
                    .HasColumnName("WCWin");

                entity.Property(e => e.Wswin)
                    .HasMaxLength(1)
                    .HasColumnName("WSWin");

                entity.Property(e => e._2b).HasColumnName("2B");

                entity.Property(e => e._3b).HasColumnName("3B");
                entity.HasMany(e => e.BattingSeasons).WithOne(e => e.Team);
            });

            modelBuilder.Entity<TeamsFranchise>(entity =>
            {
                entity.HasKey(e => e.FranchId)
                    .HasName("TeamsFranchises$Index_D181F923_2BF9_4281");

                entity.Property(e => e.FranchId)
                    .HasMaxLength(3)
                    .HasColumnName("franchID");

                entity.Property(e => e.Active)
                    .HasMaxLength(2)
                    .HasColumnName("active");

                entity.Property(e => e.FranchName)
                    .HasMaxLength(50)
                    .HasColumnName("franchName");

                entity.Property(e => e.Naassoc)
                    .HasMaxLength(3)
                    .HasColumnName("NAassoc");
            });

            modelBuilder.Entity<TeamsHalf>(entity =>
            {
                entity.HasKey(e => new { e.YearId, e.TeamId, e.LgId, e.Half })
                    .HasName("TeamsHalf$Index_3FD773F5_2FC0_415C");

                entity.ToTable("TeamsHalf");

                entity.HasIndex(e => e.DivId, "TeamsHalf$divID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(3)
                    .HasColumnName("teamID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(2)
                    .HasColumnName("lgID");

                entity.Property(e => e.Half).HasMaxLength(1);

                entity.Property(e => e.DivId)
                    .HasMaxLength(1)
                    .HasColumnName("divID");

                entity.Property(e => e.DivWin).HasMaxLength(1);
            });

            modelBuilder.Entity<War>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("war");

                entity.Property(e => e.BatWaa).HasColumnName("batWAA");

                entity.Property(e => e.BatWar).HasColumnName("batWAR");

                entity.Property(e => e.BbrefId)
                    .HasMaxLength(50)
                    .HasColumnName("bbrefId");

                entity.Property(e => e.LgId)
                    .HasMaxLength(50)
                    .HasColumnName("lgId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PitWaa).HasColumnName("pitWAA");

                entity.Property(e => e.PitWar).HasColumnName("pitWAR");

                entity.Property(e => e.StintId).HasColumnName("stintId");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(50)
                    .HasColumnName("teamId");

                entity.Property(e => e.Waa).HasColumnName("WAA");

                entity.Property(e => e.War1).HasColumnName("WAR");

                entity.Property(e => e.YearId).HasColumnName("yearId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
