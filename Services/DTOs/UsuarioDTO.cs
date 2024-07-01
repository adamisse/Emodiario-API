namespace Emodiario.Services.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public List<AvaliacaoDTO>? Avaliacoes { get; set; } = new List<AvaliacaoDTO>();
}