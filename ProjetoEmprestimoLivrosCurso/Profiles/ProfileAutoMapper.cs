using AutoMapper;
using ProjetoEmprestimoLivrosCurso.Dto;
using ProjetoEmprestimoLivrosCurso.Models;

namespace ProjetoEmprestimoLivrosCurso.Profiles;

public class ProfileAutoMapper : Profile
{
    public ProfileAutoMapper()
    {
        CreateMap<LivroCriacaoDto,LivrosModel>();
    }
}
