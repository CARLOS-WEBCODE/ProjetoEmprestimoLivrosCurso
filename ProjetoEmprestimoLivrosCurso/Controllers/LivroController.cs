using Microsoft.AspNetCore.Mvc;

namespace ProjetoEmprestimoLivrosCurso.Controllers;
public class LivroController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
