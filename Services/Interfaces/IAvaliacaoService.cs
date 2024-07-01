using Emodiario.Services.DTOs;

namespace Emodiario.Services.Interfaces;

public interface IAvaliacaoService
{
    Task<AvaliacaoDTO> CriaAvaliacaoAsync(CriaAvaliacaoDTO avaliacaoDto);

    Task<List<AvaliacaoDTO>> GetAvaliacoesByUsuarioIdAsync(int usuarioId, int? categoriaId);
}