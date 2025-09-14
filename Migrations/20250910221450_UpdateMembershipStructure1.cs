using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMembershipStructure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipClubMembers",
                table: "MembershipClubMembers");

            migrationBuilder.DropIndex(
                name: "IX_MembershipClubMembers_IdMembership",
                table: "MembershipClubMembers");

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MembershipClubMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipClubMembers",
                table: "MembershipClubMembers",
                columns: new[] { "IdMembership", "IdClubMember" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "IdCompetition",
                keyValue: 6,
                column: "Location",
                value: "Prijedor");

            migrationBuilder.InsertData(
                table: "MembershipClubMembers",
                columns: new[] { "IdClubMember", "IdMembership" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 9, 1 },
                    { 4, 2 },
                    { 8, 2 },
                    { 1, 3 },
                    { 7, 3 },
                    { 10, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "IdMembership",
                keyValue: 1,
                columns: new[] { "Duration", "Type" },
                values: new object[] { new TimeSpan(30, 0, 0, 0, 0), "Jul24" });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "IdMembership",
                keyValue: 2,
                columns: new[] { "Duration", "Type" },
                values: new object[] { new TimeSpan(180, 0, 0, 0, 0), "Polugodisnja25" });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "IdMembership",
                keyValue: 3,
                columns: new[] { "Duration", "Type" },
                values: new object[] { new TimeSpan(365, 0, 0, 0, 0), "Godisnja25" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipClubMembers",
                table: "MembershipClubMembers");

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "MembershipClubMembers",
                keyColumns: new[] { "IdClubMember", "IdMembership" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MembershipClubMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipClubMembers",
                table: "MembershipClubMembers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "IdCompetition",
                keyValue: 6,
                column: "Location",
                value: " Prijedor");

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

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "IdMembership",
                keyValue: 1,
                columns: new[] { "Duration", "Type" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly" });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "IdMembership",
                keyValue: 2,
                columns: new[] { "Duration", "Type" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Semi-Annual" });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "IdMembership",
                keyValue: 3,
                columns: new[] { "Duration", "Type" },
                values: new object[] { new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual" });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipClubMembers_IdMembership",
                table: "MembershipClubMembers",
                column: "IdMembership");
        }
    }
}
