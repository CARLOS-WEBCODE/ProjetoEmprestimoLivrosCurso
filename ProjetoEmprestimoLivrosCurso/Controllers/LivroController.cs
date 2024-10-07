using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimoLivrosCurso.Dto;
using ProjetoEmprestimoLivrosCurso.Models;
using ProjetoEmprestimoLivrosCurso.Services.LivroService;

namespace ProjetoEmprestimoLivrosCurso.Controllers;
public class LivroController : Controller
{
    private readonly ILivroInterface _livroInterface;
    public LivroController(ILivroInterface livroInterface)
    {
        _livroInterface = livroInterface;
    }

    public async Task<ActionResult<List<LivrosModel>>> Index()
    {
        var livros = await _livroInterface.BuscarLivros();

        return View(livros);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Cadastrar(LivroCriacaoDto livrosCriacaoDto, IFormFile foto)
    {
        if (foto != null)
        {
            if (ModelState.IsValid)
            {
                
                if (!_livroInterface.VerificaSeJaExisteCadastro(livrosCriacaoDto))
                {
                    return View(livrosCriacaoDto);
                }

                var livro = await _livroInterface.Cadastrar(livrosCriacaoDto, foto);

                return RedirectToAction("Index");

            }
            else
            {
                return View(livrosCriacaoDto);
            }
        }
        else
        {
            return View(livrosCriacaoDto);
        }
    }
}
