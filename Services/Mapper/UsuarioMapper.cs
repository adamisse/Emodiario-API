using Emodiario.Models;
using Emodiario.Services.Crypto;

namespace Emodiario.Services.Mapper
{
    public static class UsuarioMapper
    {
        public static Usuario ToUsuario(this CriaUsuarioDTO dto)
        {
            return new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                SenhaHash = SenhaUtils.HashPassword(dto.Senha!)
            };
        }

        public static UsuarioDTO ToUsuarioDto(this Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone
            };
        }
    }
}