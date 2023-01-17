using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo4.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Name1, ImageUrl) Values('Bebidas','bebidas.jpg')");
            mb.Sql("Insert into Categorias(Name1, ImageUrl) Values('Lanches','lanches.jpg')");
            mb.Sql("Insert into Categorias(Name1, ImageUrl) Values('Sobremesas','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");  
        }
    }
}
