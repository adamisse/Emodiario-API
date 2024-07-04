using Emodiario.Services.DTOs;

namespace Emodiario.Services.Interfaces;

public interface IAvaliacaoService
{
    Task<AvaliacaoDTO> CriaAvaliacaoAsync(int idCategoria, CriaAvaliacaoDTO avaliacaoDto);

    Task<List<AvaliacaoDTO>> GetAvaliacoesByCategoriaIdAsync(int idCategoria);
}