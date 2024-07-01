using Emodiario.Data.Configuration;
using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using Emodiario.Services.Mapper;

namespace Emodiario.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _dbContext;

    public CategoriaService(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<CategoriaDTO> CriaCategoriaAsync(CriaCategoriaDTO categoriaDto)
    {
        var categoria = categoriaDto.ToCategoria();

        _dbContext.Categorias.Add(categoria);
        await _dbContext.SaveChangesAsync();

        return categoria.ToCategoriaDto();
    }
}