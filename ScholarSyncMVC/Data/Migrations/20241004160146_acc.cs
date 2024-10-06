using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScholarSyncMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class acc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Scholarships_ScholarshipId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Scholarships_ScholarShipId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_Categories_CategoryId",
                table: "Scholarships");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_Countries_CountryId",
                table: "Scholarships");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_Departments_DepartmentId",
                table: "Scholarships");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_Universities_UniversityId",
                table: "Scholarships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scholarships",
                table: "Scholarships");

            migrationBuilder.RenameTable(
                name: "Scholarships",
                newName: "Scholarship");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarships_UniversityId",
                table: "Scholarship",
                newName: "IX_Scholarship_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarships_DepartmentId",
                table: "Scholarship",
                newName: "IX_Scholarship_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarships_CountryId",
                table: "Scholarship",
                newName: "IX_Scholarship_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarships_CategoryId",
                table: "Scholarship",
                newName: "IX_Scholarship_CategoryId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scholarship",
                table: "Scholarship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Scholarship_ScholarshipId",
                table: "Applications",
                column: "ScholarshipId",
                principalTable: "Scholarship",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Scholarship_ScholarShipId",
                table: "Requirements",
                column: "ScholarShipId",
                principalTable: "Scholarship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarship_Categories_CategoryId",
                table: "Scholarship",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarship_Countries_CountryId",
                table: "Scholarship",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarship_Departments_DepartmentId",
                table: "Scholarship",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarship_Universities_UniversityId",
                table: "Scholarship",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Scholarship_ScholarshipId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Scholarship_ScholarShipId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarship_Categories_CategoryId",
                table: "Scholarship");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarship_Countries_CountryId",
                table: "Scholarship");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarship_Departments_DepartmentId",
                table: "Scholarship");

            migrationBuilder.DropForeignKey(
                name: "FK_Scholarship_Universities_UniversityId",
                table: "Scholarship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scholarship",
                table: "Scholarship");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Scholarship",
                newName: "Scholarships");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarship_UniversityId",
                table: "Scholarships",
                newName: "IX_Scholarships_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarship_DepartmentId",
                table: "Scholarships",
                newName: "IX_Scholarships_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarship_CountryId",
                table: "Scholarships",
                newName: "IX_Scholarships_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarship_CategoryId",
                table: "Scholarships",
                newName: "IX_Scholarships_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scholarships",
                table: "Scholarships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Scholarships_ScholarshipId",
                table: "Applications",
                column: "ScholarshipId",
                principalTable: "Scholarships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Scholarships_ScholarShipId",
                table: "Requirements",
                column: "ScholarShipId",
                principalTable: "Scholarships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_Categories_CategoryId",
                table: "Scholarships",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_Countries_CountryId",
                table: "Scholarships",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_Departments_DepartmentId",
                table: "Scholarships",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_Universities_UniversityId",
                table: "Scholarships",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
