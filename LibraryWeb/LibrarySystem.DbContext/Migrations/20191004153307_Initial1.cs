using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.DbContext.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                column: "ConcurrencyStamp",
                value: "d8458760-9cca-4dff-8e37-d0aaa33dbdf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69e7930c-3df5-4261-99cf-0352eb018a91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "928584d2-efee-4f90-a7a2-3b917ef4dc34", "AQAAAAEAACcQAAAAEFI2Oz2odIAXG1gSm2d13ao/S8oSZGJxHBpE7aa2NgZ/RW42LUpKXwD5QQ0me/5dKQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "830b1e20-fd26-4ae8-b6a6-b0d68c25871b", "AQAAAAEAACcQAAAAEAUDfZr89Bn7m01zQplk0cj9LSmvCauQC+ShjneB++MhbEBErN6bhAerBUeGX5ZpRw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77aedcd5-c539-40cd-b88e-e30ff108e6b8",
                column: "ConcurrencyStamp",
                value: "6fb78ff6-dbf7-44e9-b8e4-0ac70c871d57");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69e7930c-3df5-4261-99cf-0352eb018a91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be037cc6-468a-446e-a5dc-eb3ed43d2c76", "AQAAAAEAACcQAAAAEJQVBjYG+QIqTcL1ABe8G3PEmCiCV36I3CFus/CRAVhd4RH2XkmJ0yGFk8q5b7Cq9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c51711ce-15b1-4c86-adb8-00bf52f078c9", "AQAAAAEAACcQAAAAEIFqGYha9ouH/CaTcmBdS1u77ZTR6SzNH0cJFtkRRMP/xuUcZ7MmT2ZRAYWzHCMzMg==" });
        }
    }
}
