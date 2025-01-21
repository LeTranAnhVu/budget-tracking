﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetTracking.Db.Migrations
{
    /// <inheritdoc />
    public partial class DropSubCategoryIdColumnInExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Expenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
