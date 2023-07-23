using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCTrial.Migrations
{
    public partial class newcolumnadding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "Language",
            //    table: "books",
            //    nullable: true,
            //    oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "books",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
