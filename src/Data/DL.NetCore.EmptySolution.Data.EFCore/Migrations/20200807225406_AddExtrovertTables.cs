using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.NetCore.EmptySolution.Data.EFCore.Migrations
{
    public partial class AddExtrovertTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Extrovert",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrovert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtrovertFriendship",
                columns: table => new
                {
                    ExtrovertId = table.Column<string>(nullable: false),
                    ExtrovertFriendId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtrovertFriendship", x => new { x.ExtrovertId, x.ExtrovertFriendId });
                    table.ForeignKey(
                        name: "FK_ExtrovertFriendship_Extrovert_ExtrovertFriendId",
                        column: x => x.ExtrovertFriendId,
                        principalTable: "Extrovert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtrovertFriendship_Extrovert_ExtrovertId",
                        column: x => x.ExtrovertId,
                        principalTable: "Extrovert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtrovertFriendship_ExtrovertFriendId",
                table: "ExtrovertFriendship",
                column: "ExtrovertFriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtrovertFriendship");

            migrationBuilder.DropTable(
                name: "Extrovert");
        }
    }
}
