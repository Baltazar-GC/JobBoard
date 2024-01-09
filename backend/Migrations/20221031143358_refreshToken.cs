using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class refreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RefreshTokenValue = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Expiration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Used = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000def15-ac5d-464f-87d3-576fd049d902", "AQAAAAEAACcQAAAAEFOJca25V5zyvtHh1yVLu9k6mNFpOu13qlrvR0VPN81BgdQ6i94vuObwQiBtMcdm0w==", "79a45760-5869-4906-a13d-a24a4ba8709e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "272cf1fd-6e8b-4bdb-87b8-b136033fad9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d02f95a-d1d9-4908-a722-bc905397ee09", "AQAAAAEAACcQAAAAEE8kaoM8JMdWJClC/vhJ2Y3EIAk/dHPofzMUEXR7L6a1bnRsJ2JDAKYKmgbWzsh3Cg==", "c3fad76d-f13a-4d45-acef-018f771d0c98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdc961f7-6fb6-4b7e-9319-c35a8b09dd36",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0de6e09d-3b68-4072-9745-d43b42292029", "AQAAAAEAACcQAAAAEMpker5LbhOg3kBWfJkpqwC/yleYNh59bo0eHe0LP9Ycx9xK+J4SzmEw02NI8NXeCQ==", "5c5c6bcd-986e-419c-bd80-66ece8cefc9c" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "260fba02-339e-4827-8ebd-830f239c844d", "AQAAAAEAACcQAAAAEPBzyUMY5eXVWblJb7Qp8CwWJ2+25Vqe72E/o7ilAW50WPo/BRFYtHcmrKZe3w9bew==", "75a18479-240c-440e-83a3-6704fb1df07b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "272cf1fd-6e8b-4bdb-87b8-b136033fad9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94294faa-f048-4f58-b1cb-11ff9997d826", "AQAAAAEAACcQAAAAEErpsWOAkoMypaIrEs1g6i/Bp+rfT3TAaSqaBoT3KbhB4CXyqcuKagnmHg5uyL3+NQ==", "123789a4-3632-4b40-b526-a7b5e75b7d7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdc961f7-6fb6-4b7e-9319-c35a8b09dd36",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05fd21bb-9b7c-40eb-a430-035be1d01132", "AQAAAAEAACcQAAAAENbSkhK1/PcuOwU0f6we8Bf6YBAbiBoZr7urhB/vmDLbbTvdfo6UGTnAGlBOJif2rg==", "8a1dd316-798d-4f2f-beb5-008bb7dade38" });
        }
    }
}
