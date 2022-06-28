using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWasmPilet.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "healthCarePractitioners",
                columns: table => new
                {
                    PractitionerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthCarePractitioners", x => x.PractitionerId);
                });

            migrationBuilder.CreateTable(
                name: "healthCareProviders",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthCareProviders", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "healthInsuranceInfo",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceControlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthInsuranceInfo", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientId);
                });

            migrationBuilder.InsertData(
                table: "healthCarePractitioners",
                columns: new[] { "PractitionerId", "Designation", "Name", "ProviderId" },
                values: new object[,]
                {
                    { 1, "Medical Director", "Sheema Mehboob", 2 },
                    { 2, "Physical Therapist", "Danish", 1 }
                });

            migrationBuilder.InsertData(
                table: "healthCareProviders",
                columns: new[] { "ProviderId", "Description", "Name", "PhoneNumber", "location" },
                values: new object[,]
                {
                    { 1, "Baptist HealthCare has everything you need", "Baptist HealthCare", "502-111-2222", "Lousiville" },
                    { 2, "UoFL Take cares of your education, health and your well being", "UoFL Health Care", "502-111-3333", "Lousiville" },
                    { 3, "Norton's Everything You need", "Norton Health Care", "502-111-4444", "Lousiville" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "PatientId", "Age", "Email", "Gender", "PatientFirstName", "PatientLastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 39, "john.dervik@gmail.com", "Male", "Dervik", "John", "502-123-4567" },
                    { 2, 49, "Kareena.Kapoor@gmail.com", "Female", "Kapoor", "Kareena", "502-123-4568" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "healthCarePractitioners");

            migrationBuilder.DropTable(
                name: "healthCareProviders");

            migrationBuilder.DropTable(
                name: "healthInsuranceInfo");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
