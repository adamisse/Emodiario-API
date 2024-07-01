using Emodiario.Services.DTOs;

namespace Emodiario.Services.Interfaces;

public interface ICategoriaService
{
    Task<CategoriaDTO> CriaCategoriaAsync(CriaCategoriaDTO newCategoria);
}