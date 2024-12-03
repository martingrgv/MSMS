using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TodoNameMaxLength80 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TodoItems",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "091a0932-5bea-4155-9ad1-db73e28aa455",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a85bf16-3651-4c2b-aacd-769cec6ec45b", "AQAAAAIAAYagAAAAEIYj1kQ0k/obq2/SBl0RkWzr59iBSppfOI998Ya9Ygv1zyndvl7ZOTWNKVXfmKB8qw==", "b108b802-8bb5-4a0f-b527-2eccb9d5f743" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13c6c731-7d69-4db3-a3c8-1d0b77f2d26a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1d52c5b-2206-4f3e-ae89-b926d4460565", "AQAAAAIAAYagAAAAEKmCxPhn/nZEnIVEokQOHyEoec4Qs1B+a4rwOr92GktB1XcmK/NxvbH6JOW77nr1mQ==", "2fe328e2-cd6c-4179-b56f-44c0583cfa16" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TodoItems",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

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
    }
}
