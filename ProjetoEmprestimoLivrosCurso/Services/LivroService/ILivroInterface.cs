using ProjetoEmprestimoLivrosCurso.Dto;
using ProjetoEmprestimoLivrosCurso.Models;

namespace ProjetoEmprestimoLivrosCurso.Services.LivroService;

public interface ILivroInterface
{
    Task<List<LivrosModel>> BuscarLivros();

    bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto);

    Task<LivrosModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto);
}
