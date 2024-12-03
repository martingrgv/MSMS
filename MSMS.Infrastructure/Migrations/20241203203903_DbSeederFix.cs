using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbSeederFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4daf1fb-117d-430b-add9-f31e89395635", "AQAAAAIAAYagAAAAENEJbDo0HU/36vT/Y3O/NFy/2IFOWk7XiCftKPhafvcX3mIkW93Xogrc6oOa35/LIg==", "1506550f-b14c-4248-ba22-c4b9fe7a033b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d16189e2-dc22-4406-9ea2-701bd2aa7b0b", "AQAAAAIAAYagAAAAEOnQ52dcoVjpM9b4tC6X4RCM7/bFta2VXkpFK7spUYlnzF74H1ufSsHGYG9vx0D2FQ==", "6040875a-bb05-444d-916f-4918239648ce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6288136-62a1-4311-84db-7ad9f5c9e5e9", "AQAAAAIAAYagAAAAEBeon0fhpOl7bYHQFOUVTsUUEiTo0lpyfHbVCAmwex3qiXJrUDs5Ni0KdqqZ6FJUyg==", "61716790-4c17-4fe9-8b8d-c4ab9b1cb18d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a628427a-2a45-4e69-9121-84ac4b0dd412", "AQAAAAIAAYagAAAAEHBGjv4+fHzAQWZh2HVtsPKRAxYoqrZ2y/p7V4foRn1lHbjrNdtXlJ5FktaadcXoKA==", "3ab91edc-a115-4d40-b95c-0f5e79c6becf" });
        }
    }
}
