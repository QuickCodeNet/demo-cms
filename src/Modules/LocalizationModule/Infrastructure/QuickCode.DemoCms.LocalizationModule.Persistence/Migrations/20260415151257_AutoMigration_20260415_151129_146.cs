using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoCms.LocalizationModule.Persistence.Migrations
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
                name: "LANGUAGES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_DEFAULT = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NAMESPACES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NAMESPACES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGE_FALLBACKS",
                columns: table => new
                {
                    LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    FALLBACK_LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    PRIORITY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGE_FALLBACKS", x => new { x.LANGUAGE_ID, x.FALLBACK_LANGUAGE_ID });
                    table.ForeignKey(
                        name: "FK_LANGUAGE_FALLBACKS_LANGUAGES_FALLBACK_LANGUAGE_ID",
                        column: x => x.FALLBACK_LANGUAGE_ID,
                        principalTable: "LANGUAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LANGUAGE_FALLBACKS_LANGUAGES_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESOURCE_FILES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILENAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FORMAT = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    UPLOADED_BY_USER_ID = table.Column<int>(type: "int", nullable: false),
                    UPLOADED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PROCESSED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCE_FILES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESOURCE_FILES_LANGUAGES_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSLATION_KEYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAMESPACE_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DEFAULT_VALUE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSLATION_KEYS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSLATION_KEYS_NAMESPACES_NAMESPACE_ID",
                        column: x => x.NAMESPACE_ID,
                        principalTable: "NAMESPACES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSLATION_VALUES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KEY_ID = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSLATION_VALUES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSLATION_VALUES_LANGUAGES_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSLATION_VALUES_TRANSLATION_KEYS_KEY_ID",
                        column: x => x.KEY_ID,
                        principalTable: "TRANSLATION_KEYS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LANGUAGE_FALLBACKS_FALLBACK_LANGUAGE_ID",
                table: "LANGUAGE_FALLBACKS",
                column: "FALLBACK_LANGUAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LANGUAGES_IsDeleted",
                table: "LANGUAGES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_NAMESPACES_IsDeleted",
                table: "NAMESPACES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCE_FILES_IsDeleted",
                table: "RESOURCE_FILES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCE_FILES_LANGUAGE_ID",
                table: "RESOURCE_FILES",
                column: "LANGUAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATION_KEYS_IsDeleted",
                table: "TRANSLATION_KEYS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATION_KEYS_NAMESPACE_ID",
                table: "TRANSLATION_KEYS",
                column: "NAMESPACE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATION_VALUES_IsDeleted",
                table: "TRANSLATION_VALUES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATION_VALUES_KEY_ID",
                table: "TRANSLATION_VALUES",
                column: "KEY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATION_VALUES_LANGUAGE_ID",
                table: "TRANSLATION_VALUES",
                column: "LANGUAGE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "LANGUAGE_FALLBACKS");

            migrationBuilder.DropTable(
                name: "RESOURCE_FILES");

            migrationBuilder.DropTable(
                name: "TRANSLATION_VALUES");

            migrationBuilder.DropTable(
                name: "LANGUAGES");

            migrationBuilder.DropTable(
                name: "TRANSLATION_KEYS");

            migrationBuilder.DropTable(
                name: "NAMESPACES");
        }
    }
}
