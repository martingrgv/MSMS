using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TodoListNameRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TodoLists");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TodoLists",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f697af6-554e-4092-ab0a-eeea4fd85b97", "AQAAAAIAAYagAAAAEPIeq84qtOQuwVm+W7b1vm/EdqwElqTzUScznW42PQa/1NPb9b3oRKBYpRgA8kG2Cw==", "9f29a065-a933-4e05-8a36-5439b0dc1eaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f86c7061-4ff4-49d5-a15c-66dcc1d7a8df", "AQAAAAIAAYagAAAAEJ4lgJpn0jtDQ3fKy/S3jlpHCc47Yg3V7S9ZsGB9w4st/1J1ZgncHt5yN+p2FdnnKw==", "38bb97d6-b210-4c14-bbc6-a3b3af0b171f" });
        }
    }
}
