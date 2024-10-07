using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoEmprestimoLivrosCurso.Data;
using ProjetoEmprestimoLivrosCurso.Dto;
using ProjetoEmprestimoLivrosCurso.Models;

namespace ProjetoEmprestimoLivrosCurso.Services.LivroService;

public class LivroService : ILivroInterface
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private string _caminhoServidor;

    public LivroService(AppDbContext context, IWebHostEnvironment sistema, IMapper mapper)
    {
        _context = context;
        _caminhoServidor = sistema.WebRootPath;
        _mapper = mapper;
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

    public async Task<LivrosModel> Cadastrar(LivroCriacaoDto livroCriacaoDto, IFormFile foto)
    {
        try
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var nomeCaminhoDaImagem = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + livroCriacaoDto.ISBN + ".png";

            string caminhoParaSalvarImagens = _caminhoServidor + "\\Imagem\\";

            if (!Directory.Exists(caminhoParaSalvarImagens))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            }

            using (var stream = System.IO.File.Create(caminhoParaSalvarImagens + nomeCaminhoDaImagem))
            {
                foto.CopyToAsync(stream).Wait();
            }

            //var livro = new LivrosModel
            //{
            //    Titulo = livroCriacaoDto.Titulo,
            //    Capa = nomeCaminhoDaImagem,
            //    Autor = livroCriacaoDto.Autor,
            //    Descricao = livroCriacaoDto.Descricao,
            //    QuantidadeEmEstoque = livroCriacaoDto.QuantidadeEmEstoque,
            //    AnoPublicacao = livroCriacaoDto.AnoPublicacao,
            //    ISBN = livroCriacaoDto.ISBN,
            //    Genero = livroCriacaoDto.Genero
            //};

            var livro = _mapper.Map<LivrosModel>(livroCriacaoDto);
            livro.Capa = nomeCaminhoDaImagem;

            _context.Add(livro);
            await _context.SaveChangesAsync();

            return livro;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool VerificaSeJaExisteCadastro(LivroCriacaoDto livroCriacaoDto)
    {
        try
        {
            var livroBanco = _context.Livros.FirstOrDefault(livro => livro.ISBN == livroCriacaoDto.ISBN);

            if(livroBanco != null)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
