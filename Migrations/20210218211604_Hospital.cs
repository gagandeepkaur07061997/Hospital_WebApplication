using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_WebApplication.Migrations
{
    public partial class Hospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companydetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companydetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recieverdetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recieverdetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senderdetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senderdetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parcel_weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipping_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    SenderdetailId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompantdetailId = table.Column<int>(type: "int", nullable: true),
                    RecieverId = table.Column<int>(type: "int", nullable: false),
                    RecieverdetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_Companydetail_CompantdetailId",
                        column: x => x.CompantdetailId,
                        principalTable: "Companydetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_Recieverdetail_RecieverdetailId",
                        column: x => x.RecieverdetailId,
                        principalTable: "Recieverdetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_Senderdetail_SenderdetailId",
                        column: x => x.SenderdetailId,
                        principalTable: "Senderdetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expected_date_of_delivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParcelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracking_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_CompantdetailId",
                table: "Parcel",
                column: "CompantdetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RecieverdetailId",
                table: "Parcel",
                column: "RecieverdetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_SenderdetailId",
                table: "Parcel",
                column: "SenderdetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_ParcelId",
                table: "Tracking",
                column: "ParcelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracking");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropTable(
                name: "Companydetail");

            migrationBuilder.DropTable(
                name: "Recieverdetail");

            migrationBuilder.DropTable(
                name: "Senderdetail");
        }
    }
}
