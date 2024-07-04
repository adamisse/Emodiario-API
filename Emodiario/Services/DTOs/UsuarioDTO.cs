namespace Emodiario.Services.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public List<CategoriaDTO>? Categorias { get; set; } = new List<CategoriaDTO>();
}