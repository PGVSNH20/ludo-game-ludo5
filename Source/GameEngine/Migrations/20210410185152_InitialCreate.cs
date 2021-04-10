using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseDice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseSelector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSelector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiceId = table.Column<int>(type: "int", nullable: true),
                    SelectorId = table.Column<int>(type: "int", nullable: true),
                    GameSettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSetting_BaseDice_DiceId",
                        column: x => x.DiceId,
                        principalTable: "BaseDice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSetting_BaseSelector_SelectorId",
                        column: x => x.SelectorId,
                        principalTable: "BaseSelector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSetting_GameSettings_GameSettingsId",
                        column: x => x.GameSettingsId,
                        principalTable: "GameSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Save",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Save", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Save_GameSettings_SettingsId",
                        column: x => x.SettingsId,
                        principalTable: "GameSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceID = table.Column<int>(type: "int", nullable: true),
                    Roll = table.Column<int>(type: "int", nullable: true),
                    SaveDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turn_Save_SaveDataId",
                        column: x => x.SaveDataId,
                        principalTable: "Save",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSetting_DiceId",
                table: "PlayerSetting",
                column: "DiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSetting_GameSettingsId",
                table: "PlayerSetting",
                column: "GameSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSetting_SelectorId",
                table: "PlayerSetting",
                column: "SelectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Save_SettingsId",
                table: "Save",
                column: "SettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Turn_SaveDataId",
                table: "Turn",
                column: "SaveDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSetting");

            migrationBuilder.DropTable(
                name: "Turn");

            migrationBuilder.DropTable(
                name: "BaseDice");

            migrationBuilder.DropTable(
                name: "BaseSelector");

            migrationBuilder.DropTable(
                name: "Save");

            migrationBuilder.DropTable(
                name: "GameSettings");
        }
    }
}
