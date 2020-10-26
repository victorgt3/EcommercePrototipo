using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SW.Infra.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promocao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(500)", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    PromocaoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Promocao_PromocaoId",
                        column: x => x.PromocaoId,
                        principalTable: "Promocao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinho_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Promocao",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("5ee4eb7d-3311-405f-87a2-a7ccc6b67d58"), "3 por 10 reais" });

            migrationBuilder.InsertData(
                table: "Promocao",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("a72ff4c1-3bd0-4a4a-8b3b-8a65f7a07dd9"), "Leve 2 e Pague 1" });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_ProdutoId",
                table: "Carrinho",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PromocaoId",
                table: "Produto",
                column: "PromocaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Promocao");
        }
    }
}
