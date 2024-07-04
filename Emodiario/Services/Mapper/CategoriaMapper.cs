using Emodiario.Models;
using Emodiario.Services.DTOs;

namespace Emodiario.Services.Mapper;

public static class CategoriaMapper
{
    public static Categoria ToCategoria(this CriaCategoriaDTO dto)
    {
        return new Categoria
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            IdUsuario = dto.IdUsuario
        };
    }

    public static CategoriaDTO ToCategoriaDto(this Categoria categoria)
    {
        return new CategoriaDTO
        {
            Id = categoria.Id,
            Nome = categoria.Nome,
            Descricao = categoria.Descricao,
            IdUsuario = categoria.IdUsuario,
            Avaliacoes = categoria.Avaliacoes?.Select(a => a.ToAvaliacaoDto()).ToList(),
        };
    }
}