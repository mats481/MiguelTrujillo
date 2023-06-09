using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiguelTrujillo.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisterEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCleanAndJerk_Player_PlayerId",
                table: "RegisterCleanAndJerk");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterSnatch_Player_PlayerId",
                table: "RegisterSnatch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterSnatch",
                table: "RegisterSnatch");

            migrationBuilder.DropIndex(
                name: "IX_RegisterSnatch_PlayerId",
                table: "RegisterSnatch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterCleanAndJerk",
                table: "RegisterCleanAndJerk");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCleanAndJerk_PlayerId",
                table: "RegisterCleanAndJerk");

            migrationBuilder.RenameTable(
                name: "RegisterSnatch",
                newName: "RegisterSnatches");

            migrationBuilder.RenameTable(
                name: "RegisterCleanAndJerk",
                newName: "RegisterCleanAndJerks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterSnatches",
                table: "RegisterSnatches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterCleanAndJerks",
                table: "RegisterCleanAndJerks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterSnatches_PlayerId",
                table: "RegisterSnatches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCleanAndJerks_PlayerId",
                table: "RegisterCleanAndJerks",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCleanAndJerks_Player_PlayerId",
                table: "RegisterCleanAndJerks",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterSnatches_Player_PlayerId",
                table: "RegisterSnatches",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterCleanAndJerks_Player_PlayerId",
                table: "RegisterCleanAndJerks");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterSnatches_Player_PlayerId",
                table: "RegisterSnatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterSnatches",
                table: "RegisterSnatches");

            migrationBuilder.DropIndex(
                name: "IX_RegisterSnatches_PlayerId",
                table: "RegisterSnatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterCleanAndJerks",
                table: "RegisterCleanAndJerks");

            migrationBuilder.DropIndex(
                name: "IX_RegisterCleanAndJerks_PlayerId",
                table: "RegisterCleanAndJerks");

            migrationBuilder.RenameTable(
                name: "RegisterSnatches",
                newName: "RegisterSnatch");

            migrationBuilder.RenameTable(
                name: "RegisterCleanAndJerks",
                newName: "RegisterCleanAndJerk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterSnatch",
                table: "RegisterSnatch",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterCleanAndJerk",
                table: "RegisterCleanAndJerk",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterSnatch_PlayerId",
                table: "RegisterSnatch",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterCleanAndJerk_PlayerId",
                table: "RegisterCleanAndJerk",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterCleanAndJerk_Player_PlayerId",
                table: "RegisterCleanAndJerk",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterSnatch_Player_PlayerId",
                table: "RegisterSnatch",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
