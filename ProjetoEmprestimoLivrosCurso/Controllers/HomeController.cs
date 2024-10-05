using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimoLivrosCurso.Models;
using System.Diagnostics;

namespace ProjetoEmprestimoLivrosCurso.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
