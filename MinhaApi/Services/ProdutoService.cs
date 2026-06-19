using MinhaApi.Models;

namespace MinhaApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos = new()
    {
        new Produto { Id = 1, Nome = "Notebook", Preco = 3500.00m, Estoque = 10 },
        new Produto { Id = 2, Nome = "Mouse",    Preco =   89.90m, Estoque = 50 },
        new Produto { Id = 3, Nome = "Teclado",  Preco =  149.90m, Estoque = 30 },
    };

    private int _proximoId = 4;

    public IEnumerable<Produto> ObterTodos() => _produtos;

    public Produto? ObterPorId(int id) =>
        _produtos.FirstOrDefault(p => p.Id == id);

    public Produto Criar(Produto produto)
    {
        produto.Id = _proximoId++;
        _produtos.Add(produto);
        return produto;
    }

    public bool Atualizar(int id, Produto produto)
    {
        var existente = ObterPorId(id);
        if (existente is null) return false;

        existente.Nome    = produto.Nome;
        existente.Preco   = produto.Preco;
        existente.Estoque = produto.Estoque;
        return true;
    }

    public bool Deletar(int id)
    {
        var existente = ObterPorId(id);
        if (existente is null) return false;

        _produtos.Remove(existente);
        return true;
    }
}
