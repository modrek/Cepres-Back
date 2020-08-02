using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CepresTask.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "DateOfBirth", "EmailAddress", "OfficialID", "PatientName" },
                values: new object[,]
                {
                    { new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"), null, "test@test.com", 1901L, "Ahmad" },
                    { new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"), null, "test@test.com", 1902L, "sami" },
                    { new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"), null, "test@test.com", 1903L, "Mohammad" },
                    { new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"), null, "test@test.com", 1904L, "Jane" }
                });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "Id", "Key", "PatientId", "Value" },
                values: new object[,]
                {
                    { new Guid("5d0de0e4-16f6-4d09-91cd-97a2fc9119a9"), "Age", new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"), "56" },
                    { new Guid("6f16b16e-e82a-41cd-9942-0d5ef7571773"), "Diabetes", new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"), "yes" },
                    { new Guid("c0d3ce46-954d-4c9a-893a-90a6f8d08c61"), "city", new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"), "Salfeet " },
                    { new Guid("0e32bf51-c055-46bd-b0d7-25ff216fde26"), "heart", new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"), "open surgery" },
                    { new Guid("b707da9e-e038-4357-bb86-a50b81caf93a"), "Age", new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"), "35" },
                    { new Guid("8f43e70e-189b-41ef-bd3b-1263b8e7b002"), "city", new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"), "Ramallah" },
                    { new Guid("fee49da6-39cb-4bf8-afbb-36629ff442f9"), "Age", new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"), "20" },
                    { new Guid("c64c6a90-5816-4ad3-987c-511f3ed9a89c"), "city", new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"), "Jenin" },
                    { new Guid("e223e727-7f6c-4f98-ae38-6c898bbf0ea2"), "Age", new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"), "60" },
                    { new Guid("07a194fd-3c1c-46dc-8c2b-60638ae8f0d6"), "Cancer", new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"), "yes" },
                    { new Guid("70765fc9-bfc5-4be8-9b95-8cbe450adf89"), "Asthma", new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"), "yes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("07a194fd-3c1c-46dc-8c2b-60638ae8f0d6"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("0e32bf51-c055-46bd-b0d7-25ff216fde26"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("5d0de0e4-16f6-4d09-91cd-97a2fc9119a9"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("6f16b16e-e82a-41cd-9942-0d5ef7571773"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("70765fc9-bfc5-4be8-9b95-8cbe450adf89"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("8f43e70e-189b-41ef-bd3b-1263b8e7b002"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("b707da9e-e038-4357-bb86-a50b81caf93a"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("c0d3ce46-954d-4c9a-893a-90a6f8d08c61"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("c64c6a90-5816-4ad3-987c-511f3ed9a89c"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("e223e727-7f6c-4f98-ae38-6c898bbf0ea2"));

            migrationBuilder.DeleteData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: new Guid("fee49da6-39cb-4bf8-afbb-36629ff442f9"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"));
        }
    }
}
