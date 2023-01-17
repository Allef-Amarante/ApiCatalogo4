using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo4.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Name,Description,Prize,ImageUrl,Stock,DateRegister,CategoriaId) " +
                "Values('Coca-Ina Diet','Refrigerante de cokas 350ml','5.45','cocaina.jpg',50,now(),1)");

            mb.Sql("Insert into Produtos(Name,Description,Prize,ImageUrl,Stock,DateRegister,CategoriaId) " +
              "Values('Lanche de Atun','L. Atun com Ketchup','8.45','atun.jpg',15,now(),2)");

            mb.Sql("Insert into Produtos(Name,Description,Prize,ImageUrl,Stock,DateRegister,CategoriaId) " +
              "Values('Pudin Sorvert 200 g','Pudin com Nutella 200','7.45','pudin.jpg',40,now(),3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
