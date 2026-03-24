using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAdvisor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAndInterestRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AIResponse",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LoanApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "InterestRate",
                table: "LoanApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AIResponse",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoanApplications");
        }
    }
}
