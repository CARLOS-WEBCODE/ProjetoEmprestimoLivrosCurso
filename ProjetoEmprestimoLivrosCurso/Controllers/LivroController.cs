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

    [HttpGet]
    public async Task<ActionResult> Detalhes(int? id)
    {
        if(id != null)
        {
            var livro = await _livroInterface.BuscarLivroPorId(id);
            return View(livro);
        }
        return RedirectToAction("Index");
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
                    TempData["MensagemErro"] = "Código ISBN já cadastrado!";
                    return View(livrosCriacaoDto);
                }

                var livro = await _livroInterface.Cadastrar(livrosCriacaoDto, foto);

                TempData["MensagemSucesso"] = "Livro cadastrado com sucesso!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["MensagemErro"] = "Verifique os dados preenchidos!";
                return View(livrosCriacaoDto);
            }
        }
        else
        {
            TempData["MensagemErro"] = "Incluir uma imagem de capa!";
            return View(livrosCriacaoDto);
        }
    }
}
