using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "091a0932-5bea-4155-9ad1-db73e28aa455", 0, "b3900669-7f88-4815-a8bb-2958d2d8b036", "guest@mail.com", false, "Madman", "Waller", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAIAAYagAAAAEKBKQCaFdVKYZsxz3Hf7tKVjxOCHNpojONJtUdjY7n2eEXLfoyKUgb4hSJQAvUMVFw==", null, false, "880fc00d-a7d0-4add-9d29-0885dd3eb4a1", false, "guest" },
                    { "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a", 0, "07461956-a278-4ade-81b0-e1b5341ba0eb", "creator@mail.com", false, "Willson", "Smith", false, null, "CREATOR@MAIL.COM", "CREATOR", "AQAAAAIAAYagAAAAEEAePKglv/ihUfnbV3H5bvFCOWKmzzzbufd/0c1S//7Iav52UUbYkihouiaDMC0q0w==", null, false, "141589ea-c154-4da2-b574-1ee04f07dc16", false, "creator" }
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
                    { 1, "/images/default/overworld.jpg", null, 1, 0 },
                    { 2, "/images/default/nether.jpg", null, 1, 1 },
                    { 3, "/images/default/end.jpg", null, 1, 2 }
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
