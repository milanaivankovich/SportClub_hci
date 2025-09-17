using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportClub.Models;

namespace SportClub.Data
{
    public class SportClubContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<ClubMember> ClubMembers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<MembershipClubMember> MembershipClubMembers { get; set; }
        public DbSet<CompetitionClubMember> CompetitionClubMembers { get; set; }
        public DbSet<InstructorTraining> InstructorTrainings { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sportclub.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // TPT (Table Per Type) configuration
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");

            // Many-to-many: Membership <-> ClubMember
            modelBuilder.Entity<MembershipClubMember>()
                .HasKey(mc => new { mc.IdMembership, mc.IdClubMember });

            modelBuilder.Entity<MembershipClubMember>()
                .HasOne(mc => mc.Membership)
                .WithMany(m => m.MembershipClubMembers)
                .HasForeignKey(mc => mc.IdMembership);

            modelBuilder.Entity<MembershipClubMember>()
                .HasOne(mc => mc.ClubMember)
                .WithMany(c => c.MembershipClubMembers)
                .HasForeignKey(mc => mc.IdClubMember);

            // Many-to-many: Competition <-> ClubMember
            modelBuilder.Entity<Competition>()
                .HasMany(c => c.ClubMembers)
                .WithMany(cm => cm.Competitions)
                .UsingEntity<CompetitionClubMember>(
                    j => j.HasOne(cc => cc.ClubMember).WithMany().HasForeignKey(cc => cc.IdClubMember),
                    j => j.HasOne(cc => cc.Competition).WithMany().HasForeignKey(cc => cc.IdCompetition),
                    j => j.ToTable("CompetitionClubMembers")
                );

            // Many-to-many: Instructor <-> Training
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Trainings)
                .WithMany(t => t.Instructors)
                .UsingEntity<InstructorTraining>(
                    j => j.HasOne(it => it.Training).WithMany().HasForeignKey(it => it.IdTraining),
                    j => j.HasOne(it => it.Instructor).WithMany().HasForeignKey(it => it.IdInstructor),
                    j => j.ToTable("InstructorTrainings")
                );

            // One-to-many: Attendance -> ClubMember
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.ClubMember)
                .WithMany(cm => cm.Attendances)
                .HasForeignKey(a => a.IdClubMember);

            // One-to-many: Attendance -> Training
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Training)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.IdTraining);

            modelBuilder.Entity<UserSettings>().HasKey(us => us.Id);

            modelBuilder.Entity<UserSettings>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(us => us.UserId);

            // Seed data
            modelBuilder.Entity<Admin>().HasData(
                new Admin { IdUser = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin123" }
            );

            // Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { IdUser = 2, FirstName = "Marko", LastName = "Petrovic", Username = "marko_p", Password = "pass123" },
                new Instructor { IdUser = 3, FirstName = "Ana", LastName = "Jovanovic", Username = "ana_j", Password = "pass456" },
                new Instructor { IdUser = 4, FirstName = "Nikola", LastName = "Tomic", Username = "nikola_t", Password = "pass789" },
                new Instructor { IdUser = 5, FirstName = "Jelena", LastName = "Kostic", Username = "jelena_k", Password = "pass101" },
                new Instructor { IdUser = 6, FirstName = "Stefan", LastName = "Milic", Username = "stefan_m", Password = "pass202" }
            );

            // Club Members
            modelBuilder.Entity<ClubMember>().HasData(
                new ClubMember { IdClubMember = 1, FirstName = "Petar", LastName = "Nikolic", BirthDate = new DateTime(1995, 5, 12), Active = true },
                new ClubMember { IdClubMember = 2, FirstName = "Marija", LastName = "Stojanovic", BirthDate = new DateTime(1998, 8, 23), Active = true },
                new ClubMember { IdClubMember = 3, FirstName = "Ivan", LastName = "Djokovic", BirthDate = new DateTime(1993, 3, 15), Active = true },
                new ClubMember { IdClubMember = 4, FirstName = "Katarina", LastName = "Lazic", BirthDate = new DateTime(2000, 11, 7), Active = true },
                new ClubMember { IdClubMember = 5, FirstName = "Milos", LastName = "Radovic", BirthDate = new DateTime(1997, 6, 30), Active = true },
                new ClubMember { IdClubMember = 6, FirstName = "Tamara", LastName = "Vasic", BirthDate = new DateTime(1994, 2, 19), Active = true },
                new ClubMember { IdClubMember = 7, FirstName = "Luka", LastName = "Markovic", BirthDate = new DateTime(1999, 9, 5), Active = true },
                new ClubMember { IdClubMember = 8, FirstName = "Sofija", LastName = "Ilic", BirthDate = new DateTime(1996, 4, 25), Active = true },
                new ClubMember { IdClubMember = 9, FirstName = "Dusan", LastName = "Kovacevic", BirthDate = new DateTime(1992, 12, 10), Active = true },
                new ClubMember { IdClubMember = 10, FirstName = "Jovana", LastName = "Zivkovic", BirthDate = new DateTime(2001, 7, 14), Active = true }
            );

            // Memberships (updated with TimeSpan and new Type values)
            modelBuilder.Entity<Membership>().HasData(
                new Membership { IdMembership = 1, Type = "Jul24", Price = 30, Duration = TimeSpan.FromDays(30) },
                new Membership { IdMembership = 2, Type = "Polugodisnja25", Price = 150, Duration = TimeSpan.FromDays(180) },
                new Membership { IdMembership = 3, Type = "Godisnja25", Price = 280, Duration = TimeSpan.FromDays(365) }
            );

            // Trainings (unchanged)
            var trainings = new List<Training>();
            string[] trainingTypes = { "Boulder", "Cardio", "Speed", "Lead", "Mobility" };
            for (int i = 1; i <= 100; i++)
            {
                trainings.Add(new Training
                {
                    IdTraining = i,
                    Name = $"Training {i}",
                    Type = trainingTypes[i % trainingTypes.Length],
                    DateTime = new DateTime(2024, 1, 1).AddDays(i * 3)
                });
            }
            modelBuilder.Entity<Training>().HasData(trainings);

            // Competitions (unchanged)
            modelBuilder.Entity<Competition>().HasData(
                new Competition { IdCompetition = 1, Name = "Prvenstvo RS 1. kolo", Date = new DateTime(2024, 4, 10), Location = "Banja Luka" },
                new Competition { IdCompetition = 2, Name = "Prvenstvo BiH 1. kolo", Date = new DateTime(2024, 7, 15), Location = "Sarajevo" },
                new Competition { IdCompetition = 3, Name = "Prvenstvo RS 2. kolo", Date = new DateTime(2024, 10, 20), Location = "Prijedor" },
                new Competition { IdCompetition = 4, Name = "Balkansko prvenstvo 1. kolo", Date = new DateTime(2024, 12, 5), Location = "Mostar" },
                new Competition { IdCompetition = 5, Name = "Prvenstvo BiH 2. kolo", Date = new DateTime(2025, 1, 10), Location = "Gradiška" },
                new Competition { IdCompetition = 6, Name = "Prvenstvo RS 3. kolo", Date = new DateTime(2025, 3, 15), Location = "Prijedor" },
                new Competition { IdCompetition = 7, Name = "Prvenstvo BiH 3. kolo", Date = new DateTime(2025, 6, 20), Location = "Banja Luka" },
                new Competition { IdCompetition = 8, Name = "Penjačka liga Hrvatske", Date = new DateTime(2025, 9, 10), Location = "Zagreb" },
                new Competition { IdCompetition = 9, Name = "Balkansko prvenstvo 4. kolo", Date = new DateTime(2025, 11, 25), Location = "Koper" },
                new Competition { IdCompetition = 10, Name = "Evropsko prvenstvo", Date = new DateTime(2025, 12, 15), Location = "Ljubljana" }
            );

            // Instructor-Training assignments (unchanged)
            var instructorTrainings = new List<InstructorTraining>();
            var random = new Random(42);
            for (int i = 1; i <= 100; i++)
            {
                int instructorCount = random.Next(1, 3); // 1 or 2 instructors per training
                var instructors = new List<int> { 2, 3, 4, 5, 6 }.OrderBy(x => random.Next()).Take(instructorCount).ToList();
                foreach (var instructorId in instructors)
                {
                    instructorTrainings.Add(new InstructorTraining { IdInstructor = instructorId, IdTraining = i });
                }
            }
            modelBuilder.Entity<InstructorTraining>().HasData(instructorTrainings);

            // Attendance (unchanged)
            var attendances = new List<Attendance>();
            int attendanceId = 1;
            for (int memberId = 1; memberId <= 10; memberId++)
            {
                int attendanceCount = random.Next(10, 21); // 10-20 attendances
                var selectedTrainings = Enumerable.Range(1, 100).OrderBy(x => random.Next()).Take(attendanceCount).ToList();
                foreach (var trainingId in selectedTrainings)
                {
                    attendances.Add(new Attendance
                    {
                        IdAttendance = attendanceId++,
                        Date = trainings[trainingId - 1].DateTime,
                        IdClubMember = memberId,
                        IdTraining = trainingId
                    });
                }
            }
            modelBuilder.Entity<Attendance>().HasData(attendances);

            // Competition-ClubMember assignments (unchanged)
            var competitionClubMembers = new List<CompetitionClubMember>();
            for (int memberId = 1; memberId <= 10; memberId++)
            {
                int competitionCount = random.Next(3, 11); // 3-10 competitions
                var selectedCompetitions = Enumerable.Range(1, 10).OrderBy(x => random.Next()).Take(competitionCount).ToList();
                foreach (var competitionId in selectedCompetitions)
                {
                    competitionClubMembers.Add(new CompetitionClubMember
                    {
                        IdClubMember = memberId,
                        IdCompetition = competitionId
                    });
                }
            }
            modelBuilder.Entity<CompetitionClubMember>().HasData(competitionClubMembers);

            // Membership-ClubMember assignments (updated to remove Id and use composite key)
            var membershipClubMembers = new List<MembershipClubMember>();
            var rnd = new Random(42); // Make sure this is declared earlier if not already

            for (int memberId = 1; memberId <= 10; memberId++)
            {
                int membershipType = rnd.Next(1, 4); // 1: Jul24, 2: Polugodišnja25, 3: Godišnja25

                if (membershipType == 1)
                {
                    int monthlyCount = random.Next(2, 5);
                    for (int i = 0; i < monthlyCount; i++)
                    {
                        // Create unique membership entries by adding months
                        int monthOffset = i;
                        membershipClubMembers.Add(new MembershipClubMember
                        {
                            IdMembership = 1,
                            IdClubMember = memberId
                        });
                    }
                }
                else
                {
                    membershipClubMembers.Add(new MembershipClubMember
                    {
                        IdMembership = membershipType,
                        IdClubMember = memberId
                    });
                }
            }

            // Remove duplicates by grouping and taking only the first occurrence of each key
            var uniqueMembershipClubMembers = membershipClubMembers
                .GroupBy(m => new { m.IdMembership, m.IdClubMember })
                .Select(g => g.First())
                .ToList();

            modelBuilder.Entity<MembershipClubMember>().HasData(uniqueMembershipClubMembers);
        }
    }
}