using ApiCatalogo4.Context;
using ApiCatalogo4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ApiCatalogo4.Controllers;
[Route("[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _context;

	public CategoriaController(AppDbContext context)
	{
		_context = context;
	}


	[HttpGet("produtos")]
	public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
	{
		return Ok(_context?.Categorias?.Include(o => o.Produtos).ToList());
	}


	[HttpGet]
	public ActionResult<IEnumerable<Categoria>> List()
	{
		return Ok(_context?.Categorias?.ToList());
	}



	[HttpGet("{id}",Name = "ObterCategoria")]
	public ActionResult<Categoria> Get(int id)
	{
		try
		{
            var categoria = _context?.Categorias?.FirstOrDefault(o => o.Id == id);
            if (categoria == null)
                return BadRequest($"Categoria com id = {id}, não encontrada..."); // $ = interpolação || + = concatenação
            return Ok(categoria);
        }
		catch (Exception)
		{

			return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
		}
		

	}


	[HttpPost]
	public ActionResult Post(Categoria categoria)
	{
		if (categoria == null)
			return BadRequest();

		_context?.Categorias?.Add(categoria);
		_context?.SaveChanges();

		return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
	}


	[HttpPut]
	public ActionResult Put(int id,Categoria categoria)
	{
		if (id != categoria.Id)
			return BadRequest();

		_context.Entry(categoria).State = EntityState.Modified;
		_context.SaveChanges();
		return Ok(categoria); 

	}


	[HttpDelete("{id}")]
	public ActionResult Delete(int id)
	{
		var toDelete = _context?.Categorias?.Find(id);
		if (toDelete == null)
			return BadRequest();

		_context?.Categorias?.Remove(toDelete);
		_context?.SaveChanges();
		return Ok(toDelete);
	}

}
