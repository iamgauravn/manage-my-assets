using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace manage_my_assets.Migrations
{
    /// <inheritdoc />
    public partial class Accessory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Accessory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInserted",
                table: "Accessory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Accessory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Accessory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserIdCreated",
                table: "Accessory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUpdated",
                table: "Accessory",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accessory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateInserted", "DateUpdated", "IsDeleted", "UserIdCreated", "UserIdUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Accessory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateInserted", "DateUpdated", "IsDeleted", "UserIdCreated", "UserIdUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Accessory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateInserted", "DateUpdated", "IsDeleted", "UserIdCreated", "UserIdUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Accessory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateInserted", "DateUpdated", "IsDeleted", "UserIdCreated", "UserIdUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "DateInserted",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "UserIdCreated",
                table: "Accessory");

            migrationBuilder.DropColumn(
                name: "UserIdUpdated",
                table: "Accessory");
        }
    }
}
