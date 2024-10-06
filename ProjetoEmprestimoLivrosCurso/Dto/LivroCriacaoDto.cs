﻿using System.ComponentModel.DataAnnotations;

namespace ProjetoEmprestimoLivrosCurso.Dto;

public class LivroCriacaoDto
{
    [Required(ErrorMessage = "Insira um título!")]
    public string Titulo { get; set; } = string.Empty; //significa que é uma string vazia

    [Required(ErrorMessage = "Insira uma descrição!")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Insira uma capa!")]
    public string Capa { get; set; } = string.Empty;

    [Required(ErrorMessage = "Insira o código ISBN!")]
    public string ISBN { get; set; } = string.Empty;

    [Required(ErrorMessage = "Insira um autor!")]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Insira um Genero!")]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "Insira o ano de publicação!")]
    public int AnoPublicacao { get; set; }

    [Required(ErrorMessage = "Insira uma quantidade em estoque!")]
    public int QuantidadeEmEstoque { get; set; }
}
