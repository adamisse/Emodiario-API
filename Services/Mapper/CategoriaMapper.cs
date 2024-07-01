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
            Descricao = dto.Descricao
        };
    }

    public static CategoriaDTO ToCategoriaDto(this Categoria categoria)
    {
        return new CategoriaDTO
        {
            Id = categoria.Id,
            Descricao = categoria.Descricao
        };
    }
}