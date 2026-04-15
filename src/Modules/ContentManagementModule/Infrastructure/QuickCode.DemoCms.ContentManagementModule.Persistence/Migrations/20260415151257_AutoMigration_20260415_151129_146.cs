using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260415_151129_146 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIT_LOGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ENTITY_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_GROUP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TIMESTAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OLD_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    NEW_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CHANGED_COLUMNS = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IS_CHANGED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CHANGE_SUMMARY = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_AGENT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CORRELATION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_SUCCESS = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ERROR_MESSAGE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    HASH = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_LOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTENT_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    API_KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KIND = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTENT_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTENT_VERSIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT_TYPE_KIND = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CONTENT_ID = table.Column<int>(type: "int", nullable: false),
                    TRANSLATION_ID = table.Column<int>(type: "int", nullable: false),
                    VERSION_NUMBER = table.Column<int>(type: "int", nullable: false),
                    CONTENT_SNAPSHOT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CREATED_BY_USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTENT_VERSIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TAGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SLUG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTENT_BLOCKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTENT_BLOCKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTENT_BLOCKS_CONTENT_TYPES_CONTENT_TYPE_ID",
                        column: x => x.CONTENT_TYPE_ID,
                        principalTable: "CONTENT_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAGES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_PAGE_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'DRAFT'"),
                    PUBLISH_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAGES_CONTENT_TYPES_CONTENT_TYPE_ID",
                        column: x => x.CONTENT_TYPE_ID,
                        principalTable: "CONTENT_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PAGES_PAGES_PARENT_PAGE_ID",
                        column: x => x.PARENT_PAGE_ID,
                        principalTable: "PAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POSTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    AUTHOR_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'DRAFT'"),
                    PUBLISH_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POSTS_CONTENT_TYPES_CONTENT_TYPE_ID",
                        column: x => x.CONTENT_TYPE_ID,
                        principalTable: "CONTENT_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTENT_TAGS",
                columns: table => new
                {
                    CONTENT_TYPE_KIND = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CONTENT_ID = table.Column<int>(type: "int", nullable: false),
                    TAG_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTENT_TAGS", x => new { x.CONTENT_TYPE_KIND, x.CONTENT_ID, x.TAG_ID });
                    table.ForeignKey(
                        name: "FK_CONTENT_TAGS_TAGS_TAG_ID",
                        column: x => x.TAG_ID,
                        principalTable: "TAGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BLOCK_TRANSLATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLOCK_ID = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLOCK_TRANSLATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BLOCK_TRANSLATIONS_CONTENT_BLOCKS_BLOCK_ID",
                        column: x => x.BLOCK_ID,
                        principalTable: "CONTENT_BLOCKS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAGE_TRANSLATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PAGE_ID = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SLUG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    SEO_TITLE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SEO_DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGE_TRANSLATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAGE_TRANSLATIONS_PAGES_PAGE_ID",
                        column: x => x.PAGE_ID,
                        principalTable: "PAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POST_TRANSLATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POST_ID = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SLUG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EXCERPT = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POST_TRANSLATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POST_TRANSLATIONS_POSTS_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "POSTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLOCK_TRANSLATIONS_BLOCK_ID",
                table: "BLOCK_TRANSLATIONS",
                column: "BLOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BLOCK_TRANSLATIONS_IsDeleted",
                table: "BLOCK_TRANSLATIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CONTENT_BLOCKS_CONTENT_TYPE_ID",
                table: "CONTENT_BLOCKS",
                column: "CONTENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTENT_BLOCKS_IsDeleted",
                table: "CONTENT_BLOCKS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CONTENT_TAGS_TAG_ID",
                table: "CONTENT_TAGS",
                column: "TAG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTENT_TYPES_IsDeleted",
                table: "CONTENT_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CONTENT_VERSIONS_IsDeleted",
                table: "CONTENT_VERSIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PAGE_TRANSLATIONS_IsDeleted",
                table: "PAGE_TRANSLATIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PAGE_TRANSLATIONS_PAGE_ID",
                table: "PAGE_TRANSLATIONS",
                column: "PAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAGES_CONTENT_TYPE_ID",
                table: "PAGES",
                column: "CONTENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAGES_IsDeleted",
                table: "PAGES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PAGES_PARENT_PAGE_ID",
                table: "PAGES",
                column: "PARENT_PAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POST_TRANSLATIONS_IsDeleted",
                table: "POST_TRANSLATIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_POST_TRANSLATIONS_POST_ID",
                table: "POST_TRANSLATIONS",
                column: "POST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POSTS_CONTENT_TYPE_ID",
                table: "POSTS",
                column: "CONTENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POSTS_IsDeleted",
                table: "POSTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TAGS_IsDeleted",
                table: "TAGS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "BLOCK_TRANSLATIONS");

            migrationBuilder.DropTable(
                name: "CONTENT_TAGS");

            migrationBuilder.DropTable(
                name: "CONTENT_VERSIONS");

            migrationBuilder.DropTable(
                name: "PAGE_TRANSLATIONS");

            migrationBuilder.DropTable(
                name: "POST_TRANSLATIONS");

            migrationBuilder.DropTable(
                name: "CONTENT_BLOCKS");

            migrationBuilder.DropTable(
                name: "TAGS");

            migrationBuilder.DropTable(
                name: "PAGES");

            migrationBuilder.DropTable(
                name: "POSTS");

            migrationBuilder.DropTable(
                name: "CONTENT_TYPES");
        }
    }
}
