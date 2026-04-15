using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260415_235859_149 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASSET_FOLDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARENT_FOLDER_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PATH = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSET_FOLDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ASSET_FOLDERS_ASSET_FOLDERS_PARENT_FOLDER_ID",
                        column: x => x.PARENT_FOLDER_ID,
                        principalTable: "ASSET_FOLDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "STORAGE_PROVIDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CONFIGURATION = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IS_DEFAULT = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORAGE_PROVIDERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ASSETS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FOLDER_ID = table.Column<int>(type: "int", nullable: false),
                    FILENAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FILE_SIZE_BYTES = table.Column<long>(type: "bigint", nullable: false),
                    MIME_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KIND = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    STORAGE_PROVIDER_ID = table.Column<int>(type: "int", nullable: false),
                    STORAGE_PATH = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSETS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ASSETS_ASSET_FOLDERS_FOLDER_ID",
                        column: x => x.FOLDER_ID,
                        principalTable: "ASSET_FOLDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASSETS_STORAGE_PROVIDERS_STORAGE_PROVIDER_ID",
                        column: x => x.STORAGE_PROVIDER_ID,
                        principalTable: "STORAGE_PROVIDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASSET_METADATAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ASSET_ID = table.Column<int>(type: "int", nullable: false),
                    KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VALUE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSET_METADATAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ASSET_METADATAS_ASSETS_ASSET_ID",
                        column: x => x.ASSET_ID,
                        principalTable: "ASSETS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASSET_RENDITIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORIGINAL_ASSET_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WIDTH = table.Column<int>(type: "int", nullable: false),
                    HEIGHT = table.Column<int>(type: "int", nullable: false),
                    FILE_SIZE_BYTES = table.Column<long>(type: "bigint", nullable: false),
                    MIME_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    STORAGE_PATH = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSET_RENDITIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ASSET_RENDITIONS_ASSETS_ORIGINAL_ASSET_ID",
                        column: x => x.ORIGINAL_ASSET_ID,
                        principalTable: "ASSETS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASSET_TRANSLATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ASSET_ID = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ALT_TEXT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CAPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSET_TRANSLATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ASSET_TRANSLATIONS_ASSETS_ASSET_ID",
                        column: x => x.ASSET_ID,
                        principalTable: "ASSETS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_FOLDERS_IsDeleted",
                table: "ASSET_FOLDERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_FOLDERS_PARENT_FOLDER_ID",
                table: "ASSET_FOLDERS",
                column: "PARENT_FOLDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_METADATAS_ASSET_ID",
                table: "ASSET_METADATAS",
                column: "ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_METADATAS_IsDeleted",
                table: "ASSET_METADATAS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_RENDITIONS_IsDeleted",
                table: "ASSET_RENDITIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_RENDITIONS_ORIGINAL_ASSET_ID",
                table: "ASSET_RENDITIONS",
                column: "ORIGINAL_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_TRANSLATIONS_ASSET_ID",
                table: "ASSET_TRANSLATIONS",
                column: "ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ASSET_TRANSLATIONS_IsDeleted",
                table: "ASSET_TRANSLATIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ASSETS_FOLDER_ID",
                table: "ASSETS",
                column: "FOLDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ASSETS_IsDeleted",
                table: "ASSETS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ASSETS_STORAGE_PROVIDER_ID",
                table: "ASSETS",
                column: "STORAGE_PROVIDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STORAGE_PROVIDERS_IsDeleted",
                table: "STORAGE_PROVIDERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSET_METADATAS");

            migrationBuilder.DropTable(
                name: "ASSET_RENDITIONS");

            migrationBuilder.DropTable(
                name: "ASSET_TRANSLATIONS");

            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "ASSETS");

            migrationBuilder.DropTable(
                name: "ASSET_FOLDERS");

            migrationBuilder.DropTable(
                name: "STORAGE_PROVIDERS");
        }
    }
}
