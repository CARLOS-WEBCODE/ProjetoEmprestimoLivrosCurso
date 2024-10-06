using ProjetoEmprestimoLivrosCurso.Models;

namespace ProjetoEmprestimoLivrosCurso.Services.LivroService;

public interface ILivroInterface
{
    Task<List<LivrosModel>> BuscarLivros();
}
