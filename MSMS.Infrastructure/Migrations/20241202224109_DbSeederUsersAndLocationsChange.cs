using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbSeederUsersAndLocationsChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02759c9e-ee3e-4aba-b44b-470a2cda390e", "AQAAAAIAAYagAAAAEImRe9x7rdpzjDAO3ny520a9Z+ZuFrmQGJl4FmCWcXaxDYsUNhA58FKMCkKjDgV8cQ==", "da429aee-541c-4011-9980-ae61834a6a17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb87b4c0-01cb-4cf0-bef3-675e3699e3e3", "AQAAAAIAAYagAAAAEGSeLKc4+6ESLQzDw2WhAbHshTk93EkYrPp1Yyqhl5XYn14jxbyossCbwODWgBUysA==", "18be9819-3ec6-4b7b-91a6-23b9be1dc776" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccessModifier",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e46f2fb-8e82-4aa5-800c-88b733fcc805", "AQAAAAIAAYagAAAAEPohxZ/xCIvC9beKJhHueKSFUdJaALVHOC8rIuzzcRtOjHeu/50OfTuyL7L0fv0F+Q==", "fa4f4ff3-1480-4b02-9dd5-605f661fcee8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9ba62c0-2ac4-4d54-a610-3f301a8948a1", "AQAAAAIAAYagAAAAEOuSlaGwh3X7RsfGu4QtPlxsa+XEnic1bSQP4g1aP8DRs+8Xn24XrGfYgL/itCsTUA==", "9dfabb10-f107-4a0f-bac9-76139ed358b9" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccessModifier",
                value: 2);
        }
    }
}
