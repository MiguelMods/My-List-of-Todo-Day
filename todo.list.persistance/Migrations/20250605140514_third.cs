using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo.list.persistance.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTodoListItem_todoListItems_TodoListItemId",
                table: "UserTodoListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTodoListItem_users_UserId",
                table: "UserTodoListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTodoListItem",
                table: "UserTodoListItem");

            migrationBuilder.RenameTable(
                name: "UserTodoListItem",
                newName: "userTodoListItems");

            migrationBuilder.RenameIndex(
                name: "IX_UserTodoListItem_UserId",
                table: "userTodoListItems",
                newName: "IX_userTodoListItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTodoListItem_TodoListItemId",
                table: "userTodoListItems",
                newName: "IX_userTodoListItems_TodoListItemId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "userTodoListItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "userTodoListItems",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RowGuid",
                table: "userTodoListItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "userTodoListItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "userTodoListItems",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "userTodoListItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "userTodoListItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTodoListItems",
                table: "userTodoListItems",
                column: "UserTodoListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_userTodoListItems_todoListItems_TodoListItemId",
                table: "userTodoListItems",
                column: "TodoListItemId",
                principalTable: "todoListItems",
                principalColumn: "TodoListItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userTodoListItems_users_UserId",
                table: "userTodoListItems",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userTodoListItems_todoListItems_TodoListItemId",
                table: "userTodoListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_userTodoListItems_users_UserId",
                table: "userTodoListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userTodoListItems",
                table: "userTodoListItems");

            migrationBuilder.RenameTable(
                name: "userTodoListItems",
                newName: "UserTodoListItem");

            migrationBuilder.RenameIndex(
                name: "IX_userTodoListItems_UserId",
                table: "UserTodoListItem",
                newName: "IX_UserTodoListItem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userTodoListItems_TodoListItemId",
                table: "UserTodoListItem",
                newName: "IX_UserTodoListItem_TodoListItemId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "UserTodoListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserTodoListItem",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "RowGuid",
                table: "UserTodoListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserTodoListItem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserTodoListItem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserTodoListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserTodoListItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTodoListItem",
                table: "UserTodoListItem",
                column: "UserTodoListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTodoListItem_todoListItems_TodoListItemId",
                table: "UserTodoListItem",
                column: "TodoListItemId",
                principalTable: "todoListItems",
                principalColumn: "TodoListItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTodoListItem_users_UserId",
                table: "UserTodoListItem",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
