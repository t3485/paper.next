﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paper.Migrations
{
    public partial class paper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMarketPaper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    FullName = table.Column<string>(maxLength: 64, nullable: false),
                    SimpleName = table.Column<string>(maxLength: 16, nullable: false),
                    Exchange = table.Column<string>(nullable: true),
                    MarketTime = table.Column<DateTime>(nullable: false),
                    Industry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMarketPaper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPaperDayPricePoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Open = table.Column<decimal>(nullable: true),
                    Close = table.Column<decimal>(nullable: true),
                    High = table.Column<decimal>(nullable: true),
                    Low = table.Column<decimal>(nullable: true),
                    Turn = table.Column<decimal>(nullable: true),
                    Chg = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPaperDayPricePoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPaperWeekPricePoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Open = table.Column<decimal>(nullable: true),
                    Close = table.Column<decimal>(nullable: true),
                    High = table.Column<decimal>(nullable: true),
                    Low = table.Column<decimal>(nullable: true),
                    Turn = table.Column<decimal>(nullable: true),
                    Chg = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPaperWeekPricePoint", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPaperDayPricePoint_Code_Date",
                table: "AppPaperDayPricePoint",
                columns: new[] { "Code", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_AppPaperWeekPricePoint_Code_Date",
                table: "AppPaperWeekPricePoint",
                columns: new[] { "Code", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMarketPaper");

            migrationBuilder.DropTable(
                name: "AppPaperDayPricePoint");

            migrationBuilder.DropTable(
                name: "AppPaperWeekPricePoint");
        }
    }
}
