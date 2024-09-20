using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FVA.Migrations
{
    /// <inheritdoc />
    public partial class make_parent_org_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisation_Organisation_ParentId",
                table: "Organisation");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Organisation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisation_Organisation_ParentId",
                table: "Organisation",
                column: "ParentId",
                principalTable: "Organisation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisation_Organisation_ParentId",
                table: "Organisation");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Organisation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Organisation_Organisation_ParentId",
                table: "Organisation",
                column: "ParentId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
