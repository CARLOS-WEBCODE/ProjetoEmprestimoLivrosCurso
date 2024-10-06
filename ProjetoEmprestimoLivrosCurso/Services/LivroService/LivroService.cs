﻿using Microsoft.EntityFrameworkCore;
using ProjetoEmprestimoLivrosCurso.Data;
using ProjetoEmprestimoLivrosCurso.Models;

namespace ProjetoEmprestimoLivrosCurso.Services.LivroService;

public class LivroService : ILivroInterface
{
    private readonly AppDbContext _context;

    public LivroService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<LivrosModel>> BuscarLivros()
    {
        try
        {
            var livros = await _context.Livros.ToListAsync();
            return livros;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
