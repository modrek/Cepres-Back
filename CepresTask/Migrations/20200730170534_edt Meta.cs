using Microsoft.EntityFrameworkCore.Migrations;

namespace CepresTask.Migrations
{
    public partial class edtMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MataData_Patients_Id",
                table: "MataData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MataData",
                table: "MataData");

            migrationBuilder.RenameTable(
                name: "MataData",
                newName: "MetaData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaData",
                table: "MetaData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_PatientId",
                table: "MetaData",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaData_Patients_PatientId",
                table: "MetaData",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaData_Patients_PatientId",
                table: "MetaData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaData",
                table: "MetaData");

            migrationBuilder.DropIndex(
                name: "IX_MetaData_PatientId",
                table: "MetaData");

            migrationBuilder.RenameTable(
                name: "MetaData",
                newName: "MataData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MataData",
                table: "MataData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MataData_Patients_Id",
                table: "MataData",
                column: "Id",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
