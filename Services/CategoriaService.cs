using Emodiario.Data.Configuration;
using Emodiario.Models;
using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using Emodiario.Services.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Emodiario.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _dbContext;

    public CategoriaService(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<CategoriaDTO> CriaCategoriaAsync(int idUsuario, CriaCategoriaDTO categoriaDto)
    {
        categoriaDto.idUsuario = idUsuario;
        var categoria = categoriaDto.ToCategoria();

        _dbContext.Categorias.Add(categoria);
        await _dbContext.SaveChangesAsync();

        return categoria.ToCategoriaDto();
    }

    public async Task<CategoriaDTO> GetCategoriaByIdAsync(int idCategoria)
    {
        return (await _dbContext.Categorias
            .Include(c => c.Avaliacoes)
            .FirstAsync(c => c.Id == idCategoria))
            .ToCategoriaDto();
    }

    public async Task<List<CategoriaDTO>> GetCategoriasByUsuarioIdAsync(int idUsuario)
    {
        return await _dbContext.Categorias
            .Include(c => c.Avaliacoes)
            .Where(c => c.IdUsuario == idUsuario)
            .Select(c => c!.ToCategoriaDto())
            .ToListAsync();
    }
}