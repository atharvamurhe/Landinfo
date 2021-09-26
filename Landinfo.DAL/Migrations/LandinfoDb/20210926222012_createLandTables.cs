using Microsoft.EntityFrameworkCore.Migrations;

namespace Landinfo.DAL.Migrations.LandinfoDb
{
    public partial class createLandTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<long>(nullable: false),
                    MapId = table.Column<int>(nullable: false),
                    Rural = table.Column<string>(nullable: true),
                    Dls = table.Column<string>(nullable: false),
                    LocationLat = table.Column<double>(nullable: false),
                    LocationLong = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    OperatingAreaId = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyInfos_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyInfos_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyInfos_OperatingAreas_OperatingAreaId",
                        column: x => x.OperatingAreaId,
                        principalTable: "OperatingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyInfos_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfos_CompanyId",
                table: "PropertyInfos",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfos_FieldId",
                table: "PropertyInfos",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfos_OperatingAreaId",
                table: "PropertyInfos",
                column: "OperatingAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfos_PropertyId",
                table: "PropertyInfos",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyInfos");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "OperatingAreas");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
