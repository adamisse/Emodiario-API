using Emodiario.Models;
using Emodiario.Services.DTOs;

namespace Emodiario.Services.Mapper;

public static class AvaliacaoMapper
{
    public static Avaliacao ToAvaliacao(this CriaAvaliacaoDTO dto)
    {
        return new Avaliacao(dto.Valor, dto.Descricao, dto.DataAtualizacao, dto.IdCategoria);
    }

    public static AvaliacaoDTO ToAvaliacaoDto(this Avaliacao avaliacao)
    {
        return new AvaliacaoDTO
        {
            Id = avaliacao.Id,
            Valor = avaliacao.Valor,
            Descricao = avaliacao.Descricao,
            DataAtualizacao = avaliacao.DataAtualizacao,
            IdCategoria = avaliacao.IdCategoria
        };
    }
}