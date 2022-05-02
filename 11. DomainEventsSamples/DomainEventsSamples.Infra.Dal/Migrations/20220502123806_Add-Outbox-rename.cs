using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainEventsSamples.Infra.Dal.Migrations
{
    public partial class AddOutboxrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_outBoxEventItems",
                table: "outBoxEventItems");

            migrationBuilder.RenameTable(
                name: "outBoxEventItems",
                newName: "OutBoxEventItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutBoxEventItems",
                table: "OutBoxEventItems",
                column: "OutBoxEventItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OutBoxEventItems",
                table: "OutBoxEventItems");

            migrationBuilder.RenameTable(
                name: "OutBoxEventItems",
                newName: "outBoxEventItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_outBoxEventItems",
                table: "outBoxEventItems",
                column: "OutBoxEventItemId");
        }
    }
}
