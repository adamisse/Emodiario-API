using Emodiario.Models;
using Emodiario.Services.DTOs;

namespace Emodiario.Services.Mapper;

public static class UsuarioMapper
{
    public static Usuario ToUsuario(this CriaUsuarioDTO dto)
    {
        return new Usuario(dto.Nome!, dto.Email!, dto.Senha!, dto.Telefone!);
    }

    public static UsuarioDTO ToUsuarioDto(this Usuario usuario)
    {
        return new UsuarioDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Telefone = usuario.Telefone,
            Categorias = usuario.Categorias?.Select(c => c.ToCategoriaDto()).ToList(),
        };
    }
}