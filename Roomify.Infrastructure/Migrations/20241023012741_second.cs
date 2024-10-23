using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Roomify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dbb203a2-5cb5-4736-8c28-da8763ef31b9"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReserveId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "GroupName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "StudentId" },
                values: new object[,]
                {
                    { new Guid("55d48235-7197-4e57-96b0-8d380a9a7af1"), "shoxbaxt@gmail.com", "ShoxBaxt", "POLITO", "8754CF62B0513606377E4EB9814F08466863E3F66FCA3BAC2A2F084FB2C4A40A4F28C107DE7B6EE35A6E874FECBCE128B98E79F0CB9A5E80E46A221539ED063B", new byte[] { 243, 146, 109, 197, 58, 188, 62, 82, 98, 245, 103, 155, 170, 196, 36, 74, 243, 239, 53, 137, 30, 113, 81, 97, 144, 228, 238, 217, 135, 69, 8, 197, 119, 241, 74, 202, 193, 9, 97, 178, 212, 136, 18, 38, 203, 91, 209, 8, 179, 168, 139, 98, 227, 37, 230, 118, 101, 67, 227, 37, 121, 202, 179, 177 }, "9000010001", 1, "12345" },
                    { new Guid("6da90e89-c5d0-4394-92d0-03e02f137c3b"), "abdukholiq0907@gmail.com", "Abduxoliq", "DotNet N11", "8754CF62B0513606377E4EB9814F08466863E3F66FCA3BAC2A2F084FB2C4A40A4F28C107DE7B6EE35A6E874FECBCE128B98E79F0CB9A5E80E46A221539ED063B", new byte[] { 243, 146, 109, 197, 58, 188, 62, 82, 98, 245, 103, 155, 170, 196, 36, 74, 243, 239, 53, 137, 30, 113, 81, 97, 144, 228, 238, 217, 135, 69, 8, 197, 119, 241, 74, 202, 193, 9, 97, 178, 212, 136, 18, 38, 203, 91, 209, 8, 179, 168, 139, 98, 227, 37, 230, 118, 101, 67, 227, 37, 121, 202, 179, 177 }, "9000010001", 1, "12345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55d48235-7197-4e57-96b0-8d380a9a7af1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6da90e89-c5d0-4394-92d0-03e02f137c3b"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReserveId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "GroupName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "StudentId" },
                values: new object[] { new Guid("dbb203a2-5cb5-4736-8c28-da8763ef31b9"), "abdukholiq0907@gmail.com", "Adminaka", "DotNet N11", "Abdukholiqov", "8754CF62B0513606377E4EB9814F08466863E3F66FCA3BAC2A2F084FB2C4A40A4F28C107DE7B6EE35A6E874FECBCE128B98E79F0CB9A5E80E46A221539ED063B", new byte[] { 243, 146, 109, 197, 58, 188, 62, 82, 98, 245, 103, 155, 170, 196, 36, 74, 243, 239, 53, 137, 30, 113, 81, 97, 144, 228, 238, 217, 135, 69, 8, 197, 119, 241, 74, 202, 193, 9, 97, 178, 212, 136, 18, 38, 203, 91, 209, 8, 179, 168, 139, 98, 227, 37, 230, 118, 101, 67, 227, 37, 121, 202, 179, 177 }, "9000010001", 1, "12345" });
        }
    }
}
