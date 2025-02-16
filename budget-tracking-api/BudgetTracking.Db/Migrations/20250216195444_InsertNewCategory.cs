using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetTracking.Db.Migrations
{
    /// <inheritdoc />
    public partial class InsertNewCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ... existing code ...
            migrationBuilder.Sql(@"
            INSERT INTO ""Categories"" (""Id"", ""Name"", ""SupCategoryId"") VALUES
                (42, 'Trailer', 6),
                (43, 'Car', 6);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DELETE FROM ""Categories"" WHERE ""Id"" IN (42, 43);
            ");
        }
    }
}
