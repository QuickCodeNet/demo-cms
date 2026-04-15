using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260415_234728_148 : Migration
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
                name: "THEMES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    VERSION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEVELOPER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    REPOSITORY_URL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THEMES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SITES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DEFAULT_LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    THEME_ID = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SITES_THEMES_THEME_ID",
                        column: x => x.THEME_ID,
                        principalTable: "THEMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TEMPLATES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THEME_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FILE_PATH = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMPLATES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TEMPLATES_THEMES_THEME_ID",
                        column: x => x.THEME_ID,
                        principalTable: "THEMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOMAINS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SITE_ID = table.Column<int>(type: "int", nullable: false),
                    HOSTNAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_PRIMARY = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOMAINS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOMAINS_SITES_SITE_ID",
                        column: x => x.SITE_ID,
                        principalTable: "SITES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NAVIGATION_MENUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SITE_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LOCATION_KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NAVIGATION_MENUS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NAVIGATION_MENUS_SITES_SITE_ID",
                        column: x => x.SITE_ID,
                        principalTable: "SITES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SITE_LANGUAGES",
                columns: table => new
                {
                    SITE_ID = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    IS_ENABLED = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITE_LANGUAGES", x => new { x.SITE_ID, x.LANGUAGE_ID });
                    table.ForeignKey(
                        name: "FK_SITE_LANGUAGES_SITES_SITE_ID",
                        column: x => x.SITE_ID,
                        principalTable: "SITES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SITE_SETTINGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SITE_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VALUE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_SECRET = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITE_SETTINGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SITE_SETTINGS_SITES_SITE_ID",
                        column: x => x.SITE_ID,
                        principalTable: "SITES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NAVIGATION_ITEMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENU_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    URL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PAGE_ID = table.Column<int>(type: "int", nullable: false),
                    SORT_ORDER = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    IS_VISIBLE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NAVIGATION_ITEMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NAVIGATION_ITEMS_NAVIGATION_ITEMS_PARENT_ITEM_ID",
                        column: x => x.PARENT_ITEM_ID,
                        principalTable: "NAVIGATION_ITEMS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NAVIGATION_ITEMS_NAVIGATION_MENUS_MENU_ID",
                        column: x => x.MENU_ID,
                        principalTable: "NAVIGATION_MENUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOMAINS_IsDeleted",
                table: "DOMAINS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DOMAINS_SITE_ID",
                table: "DOMAINS",
                column: "SITE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NAVIGATION_ITEMS_IsDeleted",
                table: "NAVIGATION_ITEMS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_NAVIGATION_ITEMS_MENU_ID",
                table: "NAVIGATION_ITEMS",
                column: "MENU_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NAVIGATION_ITEMS_PARENT_ITEM_ID",
                table: "NAVIGATION_ITEMS",
                column: "PARENT_ITEM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NAVIGATION_MENUS_IsDeleted",
                table: "NAVIGATION_MENUS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_NAVIGATION_MENUS_SITE_ID",
                table: "NAVIGATION_MENUS",
                column: "SITE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SITE_SETTINGS_IsDeleted",
                table: "SITE_SETTINGS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SITE_SETTINGS_SITE_ID",
                table: "SITE_SETTINGS",
                column: "SITE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SITES_IsDeleted",
                table: "SITES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SITES_THEME_ID",
                table: "SITES",
                column: "THEME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TEMPLATES_IsDeleted",
                table: "TEMPLATES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TEMPLATES_THEME_ID",
                table: "TEMPLATES",
                column: "THEME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_THEMES_IsDeleted",
                table: "THEMES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "DOMAINS");

            migrationBuilder.DropTable(
                name: "NAVIGATION_ITEMS");

            migrationBuilder.DropTable(
                name: "SITE_LANGUAGES");

            migrationBuilder.DropTable(
                name: "SITE_SETTINGS");

            migrationBuilder.DropTable(
                name: "TEMPLATES");

            migrationBuilder.DropTable(
                name: "NAVIGATION_MENUS");

            migrationBuilder.DropTable(
                name: "SITES");

            migrationBuilder.DropTable(
                name: "THEMES");
        }
    }
}
