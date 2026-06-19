using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IProdutoService
{
    IEnumerable<Produto> ObterTodos();
    Produto? ObterPorId(int id);
    Produto Criar(Produto produto);
    bool Atualizar(int id, Produto produto);
    bool Deletar(int id);
}
