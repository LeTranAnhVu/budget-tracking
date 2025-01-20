using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetTracking.Db.Migrations
{
    /// <inheritdoc />
    public partial class InsertCategoryValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        // Insert constant values into Categories table with double quotes for Postgres
        migrationBuilder.Sql(@"
            INSERT INTO ""Categories"" (""Id"", ""Name"", ""SupCategoryId"") VALUES
                -- Operating Expenses (SupCategoryId = 1)
                (1, 'Milk', 1),
                (2, 'Sugar', 1),
                (3, 'Flavorings', 1),
                (4, 'Toppings', 1),
                (5, 'Cups', 2),
                (6, 'Cones', 2),
                (7, 'Napkins', 2),
                (8, 'Spoons', 2),
                (9, 'Gasoline', 3),
                (10, 'Diesel', 3),
                (11, 'Truck Repairs', 4),
                (12, 'Servicing', 4),
                (13, 'Electricity', 5),
                (14, 'Refrigeration Fuel', 5),
                (15, 'Ice Cream Machines', 6),
                (16, 'Freezers', 6),
                (17, 'POS Systems', 6),
                
                -- Marketing and Advertising (SupCategoryId = 7)
                (18, 'Logo Design', 7),
                (19, 'Truck Wrapping', 7),
                (20, 'Signage', 7),
                (21, 'Social Media Ads', 8),
                (22, 'Website Hosting', 8),
                (23, 'Online Promotions', 8),
                (24, 'Flyers Printing', 9),
                (25, 'Posters Distribution', 9),

                -- Staffing (SupCategoryId = 10)
                (26, 'Employee Salaries', 10),
                (27, 'Employee Payments', 10),
                (28, 'Food Handling Certification', 11),
                (29, 'Workshops', 11),
                
                -- Sales and Distribution (SupCategoryId = 12)
                (30, 'Reserved Parking Spots', 12),
                (31, 'Event Fees', 12),
                (32, 'Delivery Services', 13),

                -- Miscellaneous (SupCategoryId = 14)
                (33, 'Health Permits', 14),
                (34, 'Food Truck Permits', 14),
                (35, 'Parking Permits', 14),
                (36, 'Liability Insurance', 15),
                (37, 'Vehicle Insurance', 15),
                (38, 'Equipment Insurance', 15),
                (39, 'Cleaning Products', 16),
                (40, 'Uniforms', 16),
                (41, 'Small Tools', 16);
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the inserted data in case of rollback
            migrationBuilder.Sql(@"
            DELETE FROM ""Categories"" WHERE ""Id"" IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41);
        ");
        }
    }
}
