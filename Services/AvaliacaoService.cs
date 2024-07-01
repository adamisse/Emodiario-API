﻿using Emodiario.Data.Configuration;
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

    public async Task<AvaliacaoDTO> CriaAvaliacaoAsync(CriaAvaliacaoDTO avaliacaoDto)
    {
        var avaliacao = avaliacaoDto.ToAvaliacao();

        _dbContext.Avaliacoes.Add(avaliacao);
        await _dbContext.SaveChangesAsync();

        return avaliacao.ToAvaliacaoDto();
    }

    public async Task<List<AvaliacaoDTO>> GetAvaliacoesByUsuarioIdAsync(int idUsuario)
    {
        return await _dbContext.Avaliacoes
            .Include(a => a.Usuario)
            .Include(a => a.Categoria)
            .Where(a => a.IdUsuario == idUsuario)
            .Select(a => a.ToAvaliacaoDto())
            .ToListAsync();
    }
}