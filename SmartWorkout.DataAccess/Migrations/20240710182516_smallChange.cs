using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkout.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class smallChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowRequest_User_ReceiverId",
                table: "FollowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowRequest_User_RequesterId",
                table: "FollowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollow_User_FollowerId",
                table: "UserFollow");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollow_User_UserId",
                table: "UserFollow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollow",
                table: "UserFollow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowRequest",
                table: "FollowRequest");

            migrationBuilder.RenameTable(
                name: "UserFollow",
                newName: "UserFollows");

            migrationBuilder.RenameTable(
                name: "FollowRequest",
                newName: "FollowRequests");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollow_FollowerId",
                table: "UserFollows",
                newName: "IX_UserFollows_FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowRequest_RequesterId",
                table: "FollowRequests",
                newName: "IX_FollowRequests_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowRequest_ReceiverId",
                table: "FollowRequests",
                newName: "IX_FollowRequests_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows",
                columns: new[] { "UserId", "FollowerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowRequests",
                table: "FollowRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowRequests_User_ReceiverId",
                table: "FollowRequests",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowRequests_User_RequesterId",
                table: "FollowRequests",
                column: "RequesterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_User_FollowerId",
                table: "UserFollows",
                column: "FollowerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_User_UserId",
                table: "UserFollows",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowRequests_User_ReceiverId",
                table: "FollowRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowRequests_User_RequesterId",
                table: "FollowRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_User_FollowerId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_User_UserId",
                table: "UserFollows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowRequests",
                table: "FollowRequests");

            migrationBuilder.RenameTable(
                name: "UserFollows",
                newName: "UserFollow");

            migrationBuilder.RenameTable(
                name: "FollowRequests",
                newName: "FollowRequest");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_FollowerId",
                table: "UserFollow",
                newName: "IX_UserFollow_FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowRequests_RequesterId",
                table: "FollowRequest",
                newName: "IX_FollowRequest_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowRequests_ReceiverId",
                table: "FollowRequest",
                newName: "IX_FollowRequest_ReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollow",
                table: "UserFollow",
                columns: new[] { "UserId", "FollowerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowRequest",
                table: "FollowRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowRequest_User_ReceiverId",
                table: "FollowRequest",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowRequest_User_RequesterId",
                table: "FollowRequest",
                column: "RequesterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollow_User_FollowerId",
                table: "UserFollow",
                column: "FollowerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollow_User_UserId",
                table: "UserFollow",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
