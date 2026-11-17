using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpDemo.AbpDemo.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class InitBussinessMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBooks_AppAuthors_AuthorId",
                table: "AppBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBooks",
                table: "AppBooks");

            migrationBuilder.DropIndex(
                name: "IX_AppBooks_AuthorId",
                table: "AppBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppAuthors",
                table: "AppAuthors");

            migrationBuilder.EnsureSchema(
                name: "lookup");

            migrationBuilder.RenameTable(
                name: "AppBooks",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "AppAuthors",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    NameEn = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameEn = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    NameAr = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    DescripationEn = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    DescripationAr = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "lookup",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "lookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "AppBooks");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "AppAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBooks",
                table: "AppBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppAuthors",
                table: "AppAuthors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppBooks_AuthorId",
                table: "AppBooks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBooks_AppAuthors_AuthorId",
                table: "AppBooks",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
