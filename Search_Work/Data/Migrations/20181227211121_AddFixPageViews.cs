using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddFixPageViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "ViewsPages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViewsPages_CandidateId",
                table: "ViewsPages",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ViewsPages_Candidates_CandidateId",
                table: "ViewsPages",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViewsPages_Candidates_CandidateId",
                table: "ViewsPages");

            migrationBuilder.DropIndex(
                name: "IX_ViewsPages_CandidateId",
                table: "ViewsPages");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "ViewsPages");
        }
    }
}
