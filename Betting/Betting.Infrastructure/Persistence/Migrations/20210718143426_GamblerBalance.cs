namespace BettingSystem.Infrastructure.Betting.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class GamblerBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Gamblers",
                type: "decimal(19,4)",
                precision: 19,
                scale: 4,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Gamblers");
        }
    }
}
