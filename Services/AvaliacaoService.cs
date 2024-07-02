using Emodiario.Data.Configuration;
using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using Emodiario.Services.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Emodiario.Services;

public class AvaliacaoService : IAvaliacaoService
{
    private readonly AppDbContext _dbContext;

    public AvaliacaoService(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<AvaliacaoDTO> CriaAvaliacaoAsync(int idCategoria, CriaAvaliacaoDTO avaliacaoDto)
    {
        avaliacaoDto.IdCategoria = idCategoria;
        var avaliacao = avaliacaoDto.ToAvaliacao();

        _dbContext.Avaliacoes.Add(avaliacao);
        await _dbContext.SaveChangesAsync();

        return avaliacao.ToAvaliacaoDto();
    }

    public async Task<List<AvaliacaoDTO>> GetAvaliacoesByCategoriaIdAsync(int idCategoria)
    {
        return await _dbContext.Avaliacoes
            .Where(a => a.IdCategoria == idCategoria)
            .OrderByDescending(a => a.DataAtualizacao)
            .Select(a => a.ToAvaliacaoDto())
            .ToListAsync();
    }
}