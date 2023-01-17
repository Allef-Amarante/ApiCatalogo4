using ApiCatalogo4.Context;
using ApiCatalogo4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace ApiCatalogo4.Controllers;
[Route("[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("list")]
    public ActionResult<IEnumerable<Produto>> List()
    {
        try {return Ok(_context?.Produtos?.ToList()); }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}",Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produtos = _context?.Produtos?.FirstOrDefault(o => o.Id== id);
        if(produtos == null)
            return NotFound();

        return Ok(produtos);
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto == null)
            return BadRequest();

        _context?.Produtos?.Add(produto);
        _context?.SaveChanges();
        
        return new CreatedAtRouteResult("ObterProduto", new {id = produto.Id}, produto);

    }

    [HttpPut]
    public ActionResult Put(int id, Produto produto)
    {
        if(id != produto.Id)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context?.SaveChanges();
        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var toDelete = _context?.Produtos?.FirstOrDefault(o => o.Id== id);
        if(toDelete == null) 
            return BadRequest();

        _context?.Produtos?.Remove(toDelete);
        _context?.SaveChanges();
        return Ok(toDelete);
    }





}
