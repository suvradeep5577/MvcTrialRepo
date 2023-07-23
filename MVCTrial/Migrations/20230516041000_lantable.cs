using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCTrial.Migrations
{
    public partial class lantable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Email",
            //    table: "books",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Language",
            //    table: "books",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "lang",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lang", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lang");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "books");
        }
    }
}
