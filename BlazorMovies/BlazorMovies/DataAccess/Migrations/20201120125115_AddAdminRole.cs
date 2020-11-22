using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovies.DataAccess.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles (Id, [Name], NormalizedName)
                                   VALUES ('0217c229-d81b-4d81-b3cc-2d38d32f764b', 'Admin', 'Admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
