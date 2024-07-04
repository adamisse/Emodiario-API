using Emodiario.Services.DTOs;

namespace Emodiario.Services.Interfaces;

public interface ICategoriaService
{
    Task<CategoriaDTO> CriaCategoriaAsync(int idUsuario, CriaCategoriaDTO newCategoria);

    Task<CategoriaDTO> GetCategoriaByIdAsync(int idCategoria);

    Task<List<CategoriaDTO>> GetCategoriasByUsuarioIdAsync(int idUsuario);
}