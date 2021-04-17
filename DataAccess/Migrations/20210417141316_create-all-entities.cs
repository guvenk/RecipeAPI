using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class createallentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "metaItem",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    dataType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metaItem", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apiVersion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "version",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: true),
                    recipeId = table.Column<long>(type: "bigint", nullable: false),
                    recipeId1 = table.Column<long>(type: "bigint", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_version", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_version_recipe_recipeId",
                        column: x => x.recipeId,
                        principalSchema: "dbo",
                        principalTable: "recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_version_recipe_recipeId1",
                        column: x => x.recipeId1,
                        principalSchema: "dbo",
                        principalTable: "recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2(2)", nullable: false),
                    versionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_comment_version_versionId",
                        column: x => x.versionId,
                        principalSchema: "dbo",
                        principalTable: "version",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "media",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rawUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    storageSource = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2(2)", nullable: false),
                    versionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_media_version_versionId",
                        column: x => x.versionId,
                        principalSchema: "dbo",
                        principalTable: "version",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "property",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    metaItemId = table.Column<long>(type: "bigint", nullable: false),
                    versionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_property_metaItem_metaItemId",
                        column: x => x.metaItemId,
                        principalSchema: "dbo",
                        principalTable: "metaItem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_property_version_versionId",
                        column: x => x.versionId,
                        principalSchema: "dbo",
                        principalTable: "version",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "metaItem",
                columns: new[] { "id", "dataType", "name" },
                values: new object[,]
                {
                    { 1L, "string", "Title" },
                    { 2L, "string", "Description" },
                    { 3L, "string", "OriginCountry" },
                    { 4L, "string", "OriginCity" },
                    { 5L, "string", "Category" },
                    { 6L, "string", "Ingredient" },
                    { 7L, "bool", "IsSpicy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_versionId",
                schema: "dbo",
                table: "comment",
                column: "versionId");

            migrationBuilder.CreateIndex(
                name: "IX_media_versionId",
                schema: "dbo",
                table: "media",
                column: "versionId");

            migrationBuilder.CreateIndex(
                name: "IX_metaItem_name",
                schema: "dbo",
                table: "metaItem",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_property_metaItemId",
                schema: "dbo",
                table: "property",
                column: "metaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_property_versionId",
                schema: "dbo",
                table: "property",
                column: "versionId");

            migrationBuilder.CreateIndex(
                name: "IX_version_recipeId",
                schema: "dbo",
                table: "version",
                column: "recipeId");

            migrationBuilder.CreateIndex(
                name: "IX_version_recipeId1",
                schema: "dbo",
                table: "version",
                column: "recipeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "media",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "property",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "metaItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "version",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "recipe",
                schema: "dbo");
        }
    }
}
