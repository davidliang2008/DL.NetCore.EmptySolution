using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.NetCore.EmptySolution.Data.EFCore.Migrations
{
    public partial class AddSelfReferenceWorkPackageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPackage_WorkPackage_ParentId",
                        column: x => x.ParentId,
                        principalTable: "WorkPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackage_ParentId",
                table: "WorkPackage",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkPackage");
        }
    }
}
