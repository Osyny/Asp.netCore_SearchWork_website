using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddFixViewPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViewsPages_Resumes_ResumeId",
                table: "ViewsPages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResumeId",
                table: "ViewsPages",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ViewsPages_Resumes_ResumeId",
                table: "ViewsPages",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViewsPages_Resumes_ResumeId",
                table: "ViewsPages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResumeId",
                table: "ViewsPages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ViewsPages_Resumes_ResumeId",
                table: "ViewsPages",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
