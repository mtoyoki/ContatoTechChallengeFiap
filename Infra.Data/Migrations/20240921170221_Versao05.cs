using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Versao05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVENT_MESSAGE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventMsgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventMsg = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    Result = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Details = table.Column<string>(type: "VARCHAR(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_MESSAGE", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENT_MESSAGE");
        }
    }
}
