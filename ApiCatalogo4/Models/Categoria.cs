﻿using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo4.Models;

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();    
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Name1 { get; set; }


    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public ICollection<Produto>? Produtos{ get; set; }
}
