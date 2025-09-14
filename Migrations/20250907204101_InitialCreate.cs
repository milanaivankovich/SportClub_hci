using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportClub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubMembers",
                columns: table => new
                {
                    IdClubMember = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMembers", x => x.IdClubMember);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    IdCompetition = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.IdCompetition);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    IdMembership = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.IdMembership);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.IdTraining);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionClubMembers",
                columns: table => new
                {
                    IdCompetition = table.Column<int>(type: "INTEGER", nullable: false),
                    IdClubMember = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionClubMembers", x => new { x.IdClubMember, x.IdCompetition });
                    table.ForeignKey(
                        name: "FK_CompetitionClubMembers_ClubMembers_IdClubMember",
                        column: x => x.IdClubMember,
                        principalTable: "ClubMembers",
                        principalColumn: "IdClubMember",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionClubMembers_Competitions_IdCompetition",
                        column: x => x.IdCompetition,
                        principalTable: "Competitions",
                        principalColumn: "IdCompetition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembershipClubMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMembership = table.Column<int>(type: "INTEGER", nullable: false),
                    IdClubMember = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipClubMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipClubMembers_ClubMembers_IdClubMember",
                        column: x => x.IdClubMember,
                        principalTable: "ClubMembers",
                        principalColumn: "IdClubMember",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipClubMembers_Memberships_IdMembership",
                        column: x => x.IdMembership,
                        principalTable: "Memberships",
                        principalColumn: "IdMembership",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    IdAttendance = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdClubMember = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.IdAttendance);
                    table.ForeignKey(
                        name: "FK_Attendances_ClubMembers_IdClubMember",
                        column: x => x.IdClubMember,
                        principalTable: "ClubMembers",
                        principalColumn: "IdClubMember",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Trainings_IdTraining",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Admins_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Instructors_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorTrainings",
                columns: table => new
                {
                    IdInstructor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTrainings", x => new { x.IdInstructor, x.IdTraining });
                    table.ForeignKey(
                        name: "FK_InstructorTrainings_Instructors_IdInstructor",
                        column: x => x.IdInstructor,
                        principalTable: "Instructors",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorTrainings_Trainings_IdTraining",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClubMembers",
                columns: new[] { "IdClubMember", "Active", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petar", "Nikolic" },
                    { 2, true, new DateTime(1998, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marija", "Stojanovic" },
                    { 3, true, new DateTime(1993, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Djokovic" },
                    { 4, true, new DateTime(2000, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarina", "Lazic" },
                    { 5, true, new DateTime(1997, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milos", "Radovic" },
                    { 6, true, new DateTime(1994, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tamara", "Vasic" },
                    { 7, true, new DateTime(1999, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka", "Markovic" },
                    { 8, true, new DateTime(1996, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofija", "Ilic" },
                    { 9, true, new DateTime(1992, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dusan", "Kovacevic" },
                    { 10, true, new DateTime(2001, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jovana", "Zivkovic" }
                });

            migrationBuilder.InsertData(
                table: "Competitions",
                columns: new[] { "IdCompetition", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banja Luka", "Prvenstvo RS 1. kolo" },
                    { 2, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarajevo", "Prvenstvo BiH 1. kolo" },
                    { 3, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prijedor", "Prvenstvo RS 2. kolo" },
                    { 4, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mostar", "Balkansko prvenstvo 1. kolo" },
                    { 5, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gradiška", "Prvenstvo BiH 2. kolo" },
                    { 6, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), " Prijedor", "Prvenstvo RS 3. kolo" },
                    { 7, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banja Luka", "Prvenstvo BiH 3. kolo" },
                    { 8, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", "Penjačka liga Hrvatske" },
                    { 9, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koper", "Balkansko prvenstvo 4. kolo" },
                    { 10, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ljubljana", "Evropsko prvenstvo" }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "IdMembership", "Duration", "Price", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Monthly" },
                    { 2, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, "Semi-Annual" },
                    { 3, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 280, "Annual" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "IdTraining", "DateTime", "Name", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 1", "Cardio" },
                    { 2, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 2", "Speed" },
                    { 3, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 3", "Lead" },
                    { 4, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 4", "Mobility" },
                    { 5, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 5", "Boulder" },
                    { 6, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 6", "Cardio" },
                    { 7, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 7", "Speed" },
                    { 8, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 8", "Lead" },
                    { 9, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 9", "Mobility" },
                    { 10, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 10", "Boulder" },
                    { 11, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 11", "Cardio" },
                    { 12, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 12", "Speed" },
                    { 13, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 13", "Lead" },
                    { 14, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 14", "Mobility" },
                    { 15, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 15", "Boulder" },
                    { 16, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 16", "Cardio" },
                    { 17, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 17", "Speed" },
                    { 18, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 18", "Lead" },
                    { 19, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 19", "Mobility" },
                    { 20, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 20", "Boulder" },
                    { 21, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 21", "Cardio" },
                    { 22, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 22", "Speed" },
                    { 23, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 23", "Lead" },
                    { 24, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 24", "Mobility" },
                    { 25, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 25", "Boulder" },
                    { 26, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 26", "Cardio" },
                    { 27, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 27", "Speed" },
                    { 28, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 28", "Lead" },
                    { 29, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 29", "Mobility" },
                    { 30, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 30", "Boulder" },
                    { 31, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 31", "Cardio" },
                    { 32, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 32", "Speed" },
                    { 33, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 33", "Lead" },
                    { 34, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 34", "Mobility" },
                    { 35, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 35", "Boulder" },
                    { 36, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 36", "Cardio" },
                    { 37, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 37", "Speed" },
                    { 38, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 38", "Lead" },
                    { 39, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 39", "Mobility" },
                    { 40, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 40", "Boulder" },
                    { 41, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 41", "Cardio" },
                    { 42, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 42", "Speed" },
                    { 43, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 43", "Lead" },
                    { 44, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 44", "Mobility" },
                    { 45, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 45", "Boulder" },
                    { 46, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 46", "Cardio" },
                    { 47, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 47", "Speed" },
                    { 48, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 48", "Lead" },
                    { 49, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 49", "Mobility" },
                    { 50, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 50", "Boulder" },
                    { 51, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 51", "Cardio" },
                    { 52, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 52", "Speed" },
                    { 53, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 53", "Lead" },
                    { 54, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 54", "Mobility" },
                    { 55, new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 55", "Boulder" },
                    { 56, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 56", "Cardio" },
                    { 57, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 57", "Speed" },
                    { 58, new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 58", "Lead" },
                    { 59, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 59", "Mobility" },
                    { 60, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 60", "Boulder" },
                    { 61, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 61", "Cardio" },
                    { 62, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 62", "Speed" },
                    { 63, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 63", "Lead" },
                    { 64, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 64", "Mobility" },
                    { 65, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 65", "Boulder" },
                    { 66, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 66", "Cardio" },
                    { 67, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 67", "Speed" },
                    { 68, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 68", "Lead" },
                    { 69, new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 69", "Mobility" },
                    { 70, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 70", "Boulder" },
                    { 71, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 71", "Cardio" },
                    { 72, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 72", "Speed" },
                    { 73, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 73", "Lead" },
                    { 74, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 74", "Mobility" },
                    { 75, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 75", "Boulder" },
                    { 76, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 76", "Cardio" },
                    { 77, new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 77", "Speed" },
                    { 78, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 78", "Lead" },
                    { 79, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 79", "Mobility" },
                    { 80, new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 80", "Boulder" },
                    { 81, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 81", "Cardio" },
                    { 82, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 82", "Speed" },
                    { 83, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 83", "Lead" },
                    { 84, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 84", "Mobility" },
                    { 85, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 85", "Boulder" },
                    { 86, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 86", "Cardio" },
                    { 87, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 87", "Speed" },
                    { 88, new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 88", "Lead" },
                    { 89, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 89", "Mobility" },
                    { 90, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 90", "Boulder" },
                    { 91, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 91", "Cardio" },
                    { 92, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 92", "Speed" },
                    { 93, new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 93", "Lead" },
                    { 94, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 94", "Mobility" },
                    { 95, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 95", "Boulder" },
                    { 96, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 96", "Cardio" },
                    { 97, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 97", "Speed" },
                    { 98, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 98", "Lead" },
                    { 99, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 99", "Mobility" },
                    { 100, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Training 100", "Boulder" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Admin", "User", "admin123", "admin" },
                    { 2, "Marko", "Petrovic", "pass123", "marko_p" },
                    { 3, "Ana", "Jovanovic", "pass456", "ana_j" },
                    { 4, "Nikola", "Tomic", "pass789", "nikola_t" },
                    { 5, "Jelena", "Kostic", "pass101", "jelena_k" },
                    { 6, "Stefan", "Milic", "pass202", "stefan_m" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "IdUser",
                value: 1);

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "IdAttendance", "Date", "IdClubMember", "IdTraining" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 43 },
                    { 2, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 59 },
                    { 3, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13 },
                    { 4, new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 77 },
                    { 5, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 22 },
                    { 6, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 19 },
                    { 7, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 8, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20 },
                    { 9, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 31 },
                    { 10, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 97 },
                    { 11, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 32 },
                    { 12, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 83 },
                    { 13, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 85 },
                    { 14, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 86 },
                    { 15, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 65 },
                    { 16, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 17, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 18, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 19 },
                    { 19, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 33 },
                    { 20, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 37 },
                    { 21, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 63 },
                    { 22, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 23, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 49 },
                    { 24, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 25, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 87 },
                    { 26, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 34 },
                    { 27, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 18 },
                    { 28, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 48 },
                    { 29, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11 },
                    { 30, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 59 },
                    { 31, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 73 },
                    { 32, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 33, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 83 },
                    { 34, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 14 },
                    { 35, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 89 },
                    { 36, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 79 },
                    { 37, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 41 },
                    { 38, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 15 },
                    { 39, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7 },
                    { 40, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 33 },
                    { 41, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5 },
                    { 42, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 59 },
                    { 43, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 14 },
                    { 44, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 81 },
                    { 45, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 99 },
                    { 46, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 92 },
                    { 47, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 18 },
                    { 48, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 82 },
                    { 49, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 100 },
                    { 50, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 73 },
                    { 51, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 65 },
                    { 52, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 24 },
                    { 53, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 28 },
                    { 54, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 31 },
                    { 55, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 37 },
                    { 56, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 10 },
                    { 57, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 58, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 11 },
                    { 59, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 67 },
                    { 60, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 39 },
                    { 61, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 18 },
                    { 62, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 21 },
                    { 63, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 68 },
                    { 64, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 52 },
                    { 65, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 19 },
                    { 66, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 74 },
                    { 67, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 9 },
                    { 68, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 11 },
                    { 69, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 100 },
                    { 70, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 36 },
                    { 71, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8 },
                    { 72, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 46 },
                    { 73, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 41 },
                    { 74, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 92 },
                    { 75, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 19 },
                    { 76, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 84 },
                    { 77, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 78, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 94 },
                    { 79, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 38 },
                    { 80, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 76 },
                    { 81, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 79 },
                    { 82, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 67 },
                    { 83, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 39 },
                    { 84, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3 },
                    { 85, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 43 },
                    { 86, new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 58 },
                    { 87, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 87 },
                    { 88, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 17 },
                    { 89, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 34 },
                    { 90, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 15 },
                    { 91, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 40 },
                    { 92, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 74 },
                    { 93, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 89 },
                    { 94, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 40 },
                    { 95, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 30 },
                    { 96, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 85 },
                    { 97, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 12 },
                    { 98, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 66 },
                    { 99, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 90 },
                    { 100, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 46 },
                    { 101, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 74 },
                    { 102, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 79 },
                    { 103, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 97 },
                    { 104, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 19 },
                    { 105, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 76 },
                    { 106, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 13 },
                    { 107, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 30 },
                    { 108, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 12 },
                    { 109, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 56 },
                    { 110, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 43 },
                    { 111, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 11 },
                    { 112, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 6 },
                    { 113, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 45 },
                    { 114, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 23 },
                    { 115, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 38 },
                    { 116, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 40 },
                    { 117, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5 },
                    { 118, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 119, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 42 },
                    { 120, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 79 },
                    { 121, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 16 },
                    { 122, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 87 },
                    { 123, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 84 },
                    { 124, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 67 },
                    { 125, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 72 },
                    { 126, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 64 },
                    { 127, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 13 },
                    { 128, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 61 },
                    { 129, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 28 },
                    { 130, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 56 },
                    { 131, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 11 },
                    { 132, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 95 },
                    { 133, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 20 },
                    { 134, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 135, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 66 },
                    { 136, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 12 },
                    { 137, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 74 },
                    { 138, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 17 },
                    { 139, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 52 },
                    { 140, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7 },
                    { 141, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 32 },
                    { 142, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 73 },
                    { 143, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 90 },
                    { 144, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 66 },
                    { 145, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 83 }
                });

            migrationBuilder.InsertData(
                table: "CompetitionClubMembers",
                columns: new[] { "IdClubMember", "IdCompetition" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 5 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 7 },
                    { 4, 9 },
                    { 4, 10 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 5, 9 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 7 },
                    { 6, 9 },
                    { 6, 10 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 8 },
                    { 7, 9 },
                    { 7, 10 },
                    { 8, 6 },
                    { 8, 9 },
                    { 8, 10 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 5 },
                    { 9, 8 },
                    { 9, 9 },
                    { 10, 4 },
                    { 10, 7 },
                    { 10, 8 },
                    { 10, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                column: "IdUser",
                values: new object[]
                {
                    2,
                    3,
                    4,
                    5,
                    6
                });

            migrationBuilder.InsertData(
                table: "MembershipClubMembers",
                columns: new[] { "Id", "IdClubMember", "IdMembership" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 3 },
                    { 3, 3, 1 },
                    { 4, 3, 1 },
                    { 5, 4, 1 },
                    { 6, 4, 1 },
                    { 7, 5, 2 },
                    { 8, 6, 1 },
                    { 9, 6, 1 },
                    { 10, 7, 2 },
                    { 11, 8, 1 },
                    { 12, 8, 1 },
                    { 13, 8, 1 },
                    { 14, 9, 2 },
                    { 15, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "InstructorTrainings",
                columns: new[] { "IdInstructor", "IdTraining" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 11 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 20 },
                    { 2, 26 },
                    { 2, 28 },
                    { 2, 32 },
                    { 2, 44 },
                    { 2, 48 },
                    { 2, 49 },
                    { 2, 50 },
                    { 2, 51 },
                    { 2, 53 },
                    { 2, 63 },
                    { 2, 67 },
                    { 2, 69 },
                    { 2, 97 },
                    { 2, 99 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 10 },
                    { 3, 12 },
                    { 3, 16 },
                    { 3, 19 },
                    { 3, 21 },
                    { 3, 27 },
                    { 3, 29 },
                    { 3, 30 },
                    { 3, 32 },
                    { 3, 33 },
                    { 3, 35 },
                    { 3, 37 },
                    { 3, 41 },
                    { 3, 43 },
                    { 3, 45 },
                    { 3, 46 },
                    { 3, 47 },
                    { 3, 49 },
                    { 3, 59 },
                    { 3, 61 },
                    { 3, 62 },
                    { 3, 64 },
                    { 3, 66 },
                    { 3, 67 },
                    { 3, 68 },
                    { 3, 69 },
                    { 3, 70 },
                    { 3, 72 },
                    { 3, 73 },
                    { 3, 78 },
                    { 3, 79 },
                    { 3, 84 },
                    { 3, 85 },
                    { 3, 87 },
                    { 3, 88 },
                    { 3, 90 },
                    { 3, 91 },
                    { 3, 93 },
                    { 3, 94 },
                    { 3, 95 },
                    { 3, 96 },
                    { 3, 100 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 6 },
                    { 4, 10 },
                    { 4, 15 },
                    { 4, 22 },
                    { 4, 24 },
                    { 4, 28 },
                    { 4, 31 },
                    { 4, 33 },
                    { 4, 34 },
                    { 4, 35 },
                    { 4, 36 },
                    { 4, 39 },
                    { 4, 40 },
                    { 4, 41 },
                    { 4, 42 },
                    { 4, 51 },
                    { 4, 52 },
                    { 4, 55 },
                    { 4, 60 },
                    { 4, 61 },
                    { 4, 65 },
                    { 4, 68 },
                    { 4, 71 },
                    { 4, 74 },
                    { 4, 76 },
                    { 4, 77 },
                    { 4, 80 },
                    { 4, 81 },
                    { 4, 82 },
                    { 4, 93 },
                    { 4, 95 },
                    { 4, 97 },
                    { 5, 2 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 13 },
                    { 5, 25 },
                    { 5, 36 },
                    { 5, 42 },
                    { 5, 43 },
                    { 5, 54 },
                    { 5, 55 },
                    { 5, 56 },
                    { 5, 57 },
                    { 5, 62 },
                    { 5, 64 },
                    { 5, 72 },
                    { 5, 75 },
                    { 5, 77 },
                    { 5, 78 },
                    { 5, 79 },
                    { 5, 85 },
                    { 5, 89 },
                    { 5, 92 },
                    { 5, 100 },
                    { 6, 3 },
                    { 6, 7 },
                    { 6, 9 },
                    { 6, 14 },
                    { 6, 17 },
                    { 6, 18 },
                    { 6, 20 },
                    { 6, 23 },
                    { 6, 38 },
                    { 6, 39 },
                    { 6, 44 },
                    { 6, 46 },
                    { 6, 52 },
                    { 6, 58 },
                    { 6, 66 },
                    { 6, 71 },
                    { 6, 73 },
                    { 6, 80 },
                    { 6, 83 },
                    { 6, 86 },
                    { 6, 89 },
                    { 6, 92 },
                    { 6, 96 },
                    { 6, 98 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdClubMember",
                table: "Attendances",
                column: "IdClubMember");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdTraining",
                table: "Attendances",
                column: "IdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionClubMembers_IdCompetition",
                table: "CompetitionClubMembers",
                column: "IdCompetition");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTrainings_IdTraining",
                table: "InstructorTrainings",
                column: "IdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipClubMembers_IdClubMember",
                table: "MembershipClubMembers",
                column: "IdClubMember");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipClubMembers_IdMembership",
                table: "MembershipClubMembers",
                column: "IdMembership");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "CompetitionClubMembers");

            migrationBuilder.DropTable(
                name: "InstructorTrainings");

            migrationBuilder.DropTable(
                name: "MembershipClubMembers");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "ClubMembers");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
