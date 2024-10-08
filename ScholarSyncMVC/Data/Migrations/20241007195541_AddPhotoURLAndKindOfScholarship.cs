using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScholarSyncMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoURLAndKindOfScholarship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kindOfscholarship",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Scholarship");

            migrationBuilder.DropColumn(
                name: "kindOfscholarship",
                table: "Scholarship");
        }
    }
}
