using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BacklogServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backlogs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BacklogId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backlogs", x => new { x.UserId, x.BacklogId });
                });

            migrationBuilder.CreateTable(
                name: "BacklogItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Medium = table.Column<string>(type: "TEXT", nullable: false),
                    Series = table.Column<string>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOwned = table.Column<bool>(type: "INTEGER", nullable: false),
                    InProgress = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    BacklogId = table.Column<int>(type: "INTEGER", nullable: true),
                    BacklogUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacklogItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_BacklogItems_Backlogs_BacklogUserId_BacklogId",
                        columns: x => new { x.BacklogUserId, x.BacklogId },
                        principalTable: "Backlogs",
                        principalColumns: new[] { "UserId", "BacklogId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_BacklogItems_BacklogUserId_BacklogId",
                table: "BacklogItems",
                columns: new[] { "BacklogUserId", "BacklogId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BacklogItems");

            migrationBuilder.DropTable(
                name: "Backlogs");
        }
    }
}
