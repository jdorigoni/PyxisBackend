using Microsoft.EntityFrameworkCore.Migrations;

namespace PyxisBackend.Entities.Migrations
{
    public partial class PyxisBackendEntitiesRepositoryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    PersonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(maxLength: 100, nullable: false),
                    PersonEmail = table.Column<string>(maxLength: 100, nullable: false),
                    PersonPassword = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    PetId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(nullable: true),
                    AnimalType = table.Column<string>(nullable: false),
                    Breed = table.Column<string>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_pets_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pets_PersonId",
                table: "pets",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
