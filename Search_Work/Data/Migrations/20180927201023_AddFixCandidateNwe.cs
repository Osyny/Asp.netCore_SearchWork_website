using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddFixCandidateNwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChildrenId",
                table: "Candidates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ChildrenId",
                table: "Candidates",
                column: "ChildrenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Childrens_ChildrenId",
                table: "Candidates",
                column: "ChildrenId",
                principalTable: "Childrens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Childrens_ChildrenId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ChildrenId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Candidates");
        }
    }
}
