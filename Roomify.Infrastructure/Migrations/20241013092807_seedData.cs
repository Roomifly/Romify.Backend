using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roomify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "GroupName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "StudentId" },
                values: new object[] { new Guid("8f93a1e7-9295-49b2-b058-fd6b2ab74c12"), "abdukholiq0907@gmail.com", "Adminaka", "DotNet N11", "Abdukholiqov", "8754CF62B0513606377E4EB9814F08466863E3F66FCA3BAC2A2F084FB2C4A40A4F28C107DE7B6EE35A6E874FECBCE128B98E79F0CB9A5E80E46A221539ED063B", new byte[] { 243, 146, 109, 197, 58, 188, 62, 82, 98, 245, 103, 155, 170, 196, 36, 74, 243, 239, 53, 137, 30, 113, 81, 97, 144, 228, 238, 217, 135, 69, 8, 197, 119, 241, 74, 202, 193, 9, 97, 178, 212, 136, 18, 38, 203, 91, 209, 8, 179, 168, 139, 98, 227, 37, 230, 118, 101, 67, 227, 37, 121, 202, 179, 177 }, "9000010001", 1, "12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f93a1e7-9295-49b2-b058-fd6b2ab74c12"));
        }
    }
}
