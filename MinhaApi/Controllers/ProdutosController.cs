using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Services;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetAll() =>
        Ok(_service.ObterTodos());

    [HttpGet("{id:int}")]
    public ActionResult<Produto> GetById(int id)
    {
        var produto = _service.ObterPorId(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public ActionResult<Produto> Create(Produto produto)
    {
        var criado = _service.Criar(produto);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Produto produto)
    {
        return _service.Atualizar(id, produto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return _service.Deletar(id) ? NoContent() : NotFound();
    }
}
