using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo4.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int Id { get; set; }


    [Required]
    [StringLength(80)]
    public string? Name { get; set; }


    [Required]
    [StringLength(300)]
    public string? Description { get; set; }


    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Prize { get; set;}


    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public float Stock { get; set; }

    public DateTime DateRegister { get; set; }

    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categorias { get; set; }
}
