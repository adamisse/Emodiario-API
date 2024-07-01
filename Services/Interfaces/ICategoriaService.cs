using Emodiario.Services.DTOs;

namespace Emodiario.Services.Interfaces;

public interface ICategoriaService
{
    Task<CategoriaDTO> CriaCategoriaAsync(CriaCategoriaDTO newCategoria);

    Task<List<CategoriaDTO>> GetCategoriasByUsuarioIdAsync(int idUsuario);
}