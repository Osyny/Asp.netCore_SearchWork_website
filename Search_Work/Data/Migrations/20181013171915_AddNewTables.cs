using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Search_Work.Data.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_AspNetUsers_AccountUserId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_RecommendedVacancies_Vacancy_VacancyId",
                table: "RecommendedVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsesToResume_Vacancy_VacancyId",
                table: "ResponsesToResume");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsesToVacancy_Vacancy_VacancyId",
                table: "ResponsesToVacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedVacancies_Vacancy_VacancyId",
                table: "SavedVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_Cities_CityId",
                table: "Vacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_Employers_EmployerId",
                table: "Vacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_ExperienceOfWorks_ExperienceOfWorkId",
                table: "Vacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_FieldActivities_FieldActivityId",
                table: "Vacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_Employments_TypeEmploymentId",
                table: "Vacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_ViewsPages_Vacancy_VacancyId",
                table: "ViewsPages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacancy",
                table: "Vacancy");

            migrationBuilder.DropIndex(
                name: "IX_Employers_AccountUserId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_AccountUserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "Employers");

            migrationBuilder.RenameTable(
                name: "Vacancy",
                newName: "Vacancies");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancy_TypeEmploymentId",
                table: "Vacancies",
                newName: "IX_Vacancies_TypeEmploymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancy_FieldActivityId",
                table: "Vacancies",
                newName: "IX_Vacancies_FieldActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancy_ExperienceOfWorkId",
                table: "Vacancies",
                newName: "IX_Vacancies_ExperienceOfWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancy_EmployerId",
                table: "Vacancies",
                newName: "IX_Vacancies_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancy_CityId",
                table: "Vacancies",
                newName: "IX_Vacancies_CityId");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacancies",
                table: "Vacancies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AccountUserId",
                table: "Candidates",
                column: "AccountUserId",
                unique: true,
                filter: "[AccountUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerId",
                table: "AspNetUsers",
                column: "EmployerId",
                unique: true,
                filter: "[EmployerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employers_EmployerId",
                table: "AspNetUsers",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecommendedVacancies_Vacancies_VacancyId",
                table: "RecommendedVacancies",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsesToResume_Vacancies_VacancyId",
                table: "ResponsesToResume",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsesToVacancy_Vacancies_VacancyId",
                table: "ResponsesToVacancy",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedVacancies_Vacancies_VacancyId",
                table: "SavedVacancies",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Employers_EmployerId",
                table: "Vacancies",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_ExperienceOfWorks_ExperienceOfWorkId",
                table: "Vacancies",
                column: "ExperienceOfWorkId",
                principalTable: "ExperienceOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_FieldActivities_FieldActivityId",
                table: "Vacancies",
                column: "FieldActivityId",
                principalTable: "FieldActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Employments_TypeEmploymentId",
                table: "Vacancies",
                column: "TypeEmploymentId",
                principalTable: "Employments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViewsPages_Vacancies_VacancyId",
                table: "ViewsPages",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employers_EmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RecommendedVacancies_Vacancies_VacancyId",
                table: "RecommendedVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsesToResume_Vacancies_VacancyId",
                table: "ResponsesToResume");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsesToVacancy_Vacancies_VacancyId",
                table: "ResponsesToVacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedVacancies_Vacancies_VacancyId",
                table: "SavedVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Employers_EmployerId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_ExperienceOfWorks_ExperienceOfWorkId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_FieldActivities_FieldActivityId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Employments_TypeEmploymentId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_ViewsPages_Vacancies_VacancyId",
                table: "ViewsPages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacancies",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_AccountUserId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Vacancies",
                newName: "Vacancy");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_TypeEmploymentId",
                table: "Vacancy",
                newName: "IX_Vacancy_TypeEmploymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_FieldActivityId",
                table: "Vacancy",
                newName: "IX_Vacancy_FieldActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_ExperienceOfWorkId",
                table: "Vacancy",
                newName: "IX_Vacancy_ExperienceOfWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_EmployerId",
                table: "Vacancy",
                newName: "IX_Vacancy_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_CityId",
                table: "Vacancy",
                newName: "IX_Vacancy_CityId");

            migrationBuilder.AddColumn<string>(
                name: "AccountUserId",
                table: "Employers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacancy",
                table: "Vacancy",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AccountUserId",
                table: "Employers",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AccountUserId",
                table: "Candidates",
                column: "AccountUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_AspNetUsers_AccountUserId",
                table: "Employers",
                column: "AccountUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecommendedVacancies_Vacancy_VacancyId",
                table: "RecommendedVacancies",
                column: "VacancyId",
                principalTable: "Vacancy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsesToResume_Vacancy_VacancyId",
                table: "ResponsesToResume",
                column: "VacancyId",
                principalTable: "Vacancy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsesToVacancy_Vacancy_VacancyId",
                table: "ResponsesToVacancy",
                column: "VacancyId",
                principalTable: "Vacancy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedVacancies_Vacancy_VacancyId",
                table: "SavedVacancies",
                column: "VacancyId",
                principalTable: "Vacancy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_Cities_CityId",
                table: "Vacancy",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_Employers_EmployerId",
                table: "Vacancy",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_ExperienceOfWorks_ExperienceOfWorkId",
                table: "Vacancy",
                column: "ExperienceOfWorkId",
                principalTable: "ExperienceOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_FieldActivities_FieldActivityId",
                table: "Vacancy",
                column: "FieldActivityId",
                principalTable: "FieldActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_Employments_TypeEmploymentId",
                table: "Vacancy",
                column: "TypeEmploymentId",
                principalTable: "Employments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViewsPages_Vacancy_VacancyId",
                table: "ViewsPages",
                column: "VacancyId",
                principalTable: "Vacancy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
