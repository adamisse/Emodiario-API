using Emodiario.Models;

namespace Emodiario.Services.DTOs;

public class CategoriaDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int IdUsuario { get; set; }
    public List<AvaliacaoDTO>? Avaliacoes { get; set; } = new List<AvaliacaoDTO>();
}