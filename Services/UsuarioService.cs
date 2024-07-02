using Emodiario.Data.Configuration;
using Emodiario.Services.Crypto;
using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using Emodiario.Services.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Emodiario.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _dbContext;

    public UsuarioService(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<UsuarioDTO> CriaUsuarioAsync(CriaUsuarioDTO criaUsuarioDto)
    {
        var usuario = criaUsuarioDto.ToUsuario();

        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario.ToUsuarioDto();
    }

    public async Task<UsuarioDTO?> LoginAsync(LoginDTO loginDto)
    {
        var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (usuario != null)
            if (SenhaUtils.VerifyPassword(loginDto.Senha!, usuario!.SenhaHash!))
                return usuario.ToUsuarioDto();

        return null;
    }

    public async Task<UsuarioDTO?> GetUsuarioByIdAsync(int idUsuario)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(idUsuario);

        if (usuario != null)
            return usuario.ToUsuarioDto();

        return null;
    }

    public async Task<UsuarioDTO?> GetUsuarioByUsernameAsync(string username)
    {
        var usuario = await _dbContext
            .Usuarios
            .Include(u => u.Categorias)
            .FirstOrDefaultAsync(u => u.Nome == username || u.Email == username);

        if (usuario != null)
            return usuario.ToUsuarioDto();

        return null;
    }
}