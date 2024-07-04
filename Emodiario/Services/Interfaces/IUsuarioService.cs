using Emodiario.Services.DTOs;

namespace Emodiario.Services.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioDTO> CriaUsuarioAsync(CriaUsuarioDTO novoUsuario);

    Task<UsuarioDTO?> LoginAsync(LoginDTO loginDTO);

    Task<UsuarioDTO?> GetUsuarioByIdAsync(int userId);

    Task<UsuarioDTO?> GetUsuarioByUsernameAsync(string username);
}