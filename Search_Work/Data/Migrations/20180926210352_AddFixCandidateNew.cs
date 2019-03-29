using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddFixCandidateNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Childrens_ChildrenId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_FamilyStatuses_FamilyStatusId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ChildrenId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Candidates");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyStatusId",
                table: "Candidates",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_FamilyStatuses_FamilyStatusId",
                table: "Candidates",
                column: "FamilyStatusId",
                principalTable: "FamilyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_FamilyStatuses_FamilyStatusId",
                table: "Candidates");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyStatusId",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChildrenId",
                table: "Candidates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_FamilyStatuses_FamilyStatusId",
                table: "Candidates",
                column: "FamilyStatusId",
                principalTable: "FamilyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
