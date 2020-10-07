using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoAppMVC.Infrastructure.Migrations
{
    public partial class BlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemTag",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "ItemTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ContactMessages",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag",
                columns: new[] { "BlogId", "TagId" });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    TagId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_ItemId",
                table: "ItemTag",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Blogs_BlogId",
                table: "ItemTag",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Blogs_BlogId",
                table: "ItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag");

            migrationBuilder.DropIndex(
                name: "IX_ItemTag_ItemId",
                table: "ItemTag");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "ItemTag");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ContactMessages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag",
                columns: new[] { "ItemId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
