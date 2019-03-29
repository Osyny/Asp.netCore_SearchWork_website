using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddFixResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActiveResume",
                table: "Resumes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymousResume",
                table: "Resumes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHideContact",
                table: "Resumes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveResume",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "IsAnonymousResume",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "IsHideContact",
                table: "Resumes");
        }
    }
}
