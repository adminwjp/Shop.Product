using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Product.Infrastructure.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_catalog",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 36, nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_modification_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletion_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 20, nullable: true),
                    code = table.Column<string>(maxLength: 50, nullable: true),
                    orders = table.Column<int>(nullable: false),
                    pid = table.Column<string>(maxLength: 36, nullable: true),
                    link = table.Column<string>(maxLength: 100, nullable: true),
                    target = table.Column<string>(maxLength: 10, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    flag = table.Column<int>(nullable: false),
                    image_id = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_catalog_attribue",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 36, nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_modification_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletion_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 20, nullable: true),
                    catalog_id = table.Column<string>(maxLength: 36, nullable: true),
                    order1 = table.Column<int>(nullable: false),
                    pid = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_catalog_attribue", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_product",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 36, nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_modification_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletion_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    catalog_id = table.Column<string>(maxLength: 36, nullable: true),
                    sales = table.Column<int>(nullable: false),
                    stock = table.Column<int>(nullable: false),
                    keywords = table.Column<string>(maxLength: 100, nullable: true),
                    score = table.Column<int>(nullable: false),
                    create_account = table.Column<string>(maxLength: 20, nullable: true),
                    hit = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    price = table.Column<decimal>(nullable: true),
                    update_account = table.Column<string>(maxLength: 20, nullable: true),
                    activity_id = table.Column<string>(maxLength: 36, nullable: true),
                    status = table.Column<int>(nullable: false),
                    product_html = table.Column<string>(maxLength: 2147483647, nullable: true),
                    is_new = table.Column<string>(maxLength: 1, nullable: true),
                    introduce = table.Column<string>(maxLength: 2147483647, nullable: true),
                    search_key = table.Column<string>(maxLength: 500, nullable: true),
                    images = table.Column<string>(maxLength: 1000, nullable: true),
                    max_picture = table.Column<string>(maxLength: 100, nullable: true),
                    description = table.Column<string>(maxLength: 2147483647, nullable: true),
                    unit = table.Column<string>(maxLength: 5, nullable: true),
                    picture = table.Column<string>(maxLength: 100, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    sale = table.Column<string>(nullable: true),
                    gift_id = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_product_attribute",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 36, nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_modification_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletion_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    attribute_id = table.Column<string>(maxLength: 36, nullable: true),
                    product_id = table.Column<string>(maxLength: 36, nullable: true),
                    value = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product_attribute", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_spec",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 36, nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_modification_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletion_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    stock = table.Column<int>(nullable: false),
                    sales = table.Column<int>(nullable: false),
                    product_id = table.Column<string>(maxLength: 36, nullable: true),
                    price = table.Column<decimal>(nullable: true),
                    make_price = table.Column<decimal>(nullable: true),
                    size = table.Column<string>(maxLength: 20, nullable: true),
                    status = table.Column<string>(maxLength: 1, nullable: true),
                    color = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_spec", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_catalog");

            migrationBuilder.DropTable(
                name: "t_catalog_attribue");

            migrationBuilder.DropTable(
                name: "t_product");

            migrationBuilder.DropTable(
                name: "t_product_attribute");

            migrationBuilder.DropTable(
                name: "t_spec");
        }
    }
}
