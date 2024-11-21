using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "091a0932-5bea-4155-9ad1-db73e28aa455", 0, "2e46f2fb-8e82-4aa5-800c-88b733fcc805", "guest@mail.com", false, "Madman", "Waller", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAIAAYagAAAAEPohxZ/xCIvC9beKJhHueKSFUdJaALVHOC8rIuzzcRtOjHeu/50OfTuyL7L0fv0F+Q==", null, false, "fa4f4ff3-1480-4b02-9dd5-605f661fcee8", false, "guest" },
                    { "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a", 0, "a9ba62c0-2ac4-4d54-a610-3f301a8948a1", "creator@mail.com", false, "Willson", "Smith", false, null, "CREATOR@MAIL.COM", "CREATOR", "AQAAAAIAAYagAAAAEOuSlaGwh3X7RsfGu4QtPlxsa+XEnic1bSQP4g1aP8DRs+8Xn24XrGfYgL/itCsTUA==", null, false, "9dfabb10-f107-4a0f-bac9-76139ed358b9", false, "creator" }
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "Description", "GameVersion", "ImagePath", "IpAddress", "Name", "OwnerId", "PlayMode" },
                values: new object[] { 1, "This is my first created server!", "1.20.2", "/images/server-banners/default.jpeg", "myserver.mcserver.com", "My Server", "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a", 0 });

            migrationBuilder.InsertData(
                table: "World",
                columns: new[] { "Id", "ImagePath", "Seed", "ServerId", "WorldType" },
                values: new object[,]
                {
                    { 1, "/images/servers/default/overworld.jpg", null, 1, 0 },
                    { 2, "/images/servers/default/nether.jpg", null, 1, 1 },
                    { 3, "/images/servers/default/end.jpg", null, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AccessModifier", "Coordinates", "CreatorId", "Description", "LocationType", "Name", "WorldId" },
                values: new object[,]
                {
                    { 1, 0, "0/0/0", "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a", "My first home", 0, "My Overworld Location", 1 },
                    { 2, 2, "250/250/250", "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a", "Portal to home", 3, "My Nether Location", 2 },
                    { 3, 0, "-100/-100/-100", "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a", "Enderman farm", 5, "My End Location", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "World",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "World",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "World",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a");
        }
    }
}
