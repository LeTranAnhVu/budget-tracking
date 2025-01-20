using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetTracking.Db.Migrations
{
    /// <inheritdoc />
    public partial class InsertSupCategoryValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert constant values for SupCategories table
            migrationBuilder.Sql(@"
            INSERT INTO ""SupCategories"" (""Id"", ""Name"", ""MetaDescription"") VALUES
                (1, 'Ingredients', 'Operating Expenses'),
                (2, 'Packaging', 'Operating Expenses'),
                (3, 'Fuel', 'Operating Expenses'),
                (4, 'Maintenance', 'Operating Expenses'),
                (5, 'Utilities', 'Operating Expenses'),
                (6, 'Equipment', 'Operating Expenses'),
                (7, 'Branding Materials', 'Marketing and Advertising'),
                (8, 'Digital Advertising', 'Marketing and Advertising'),
                (9, 'Flyers and Posters', 'Marketing and Advertising'),
                (10, 'Wages', 'Staffing'),
                (11, 'Training', 'Staffing'),
                (12, 'Food Truck Parking Fees', 'Sales and Distribution'),
                (13, 'Delivery Costs', 'Sales and Distribution'),
                (14, 'Permits and Licenses', 'Miscellaneous'),
                (15, 'Insurance', 'Miscellaneous'),
                (16, 'Miscellaneous Supplies', 'Miscellaneous');
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the inserted data in case of rollback
            // Remove the inserted data in case of rollback
            migrationBuilder.Sql(@"
            DELETE FROM ""SupCategories"" WHERE ""Id"" IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        ");
        }
    }
}
