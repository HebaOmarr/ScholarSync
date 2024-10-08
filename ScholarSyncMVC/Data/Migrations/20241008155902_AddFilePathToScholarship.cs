using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScholarSyncMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFilePathToScholarship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kindOfscholarship",
                table: "Scholarship");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoURL",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Scholarship");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoURL",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "kindOfscholarship",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
