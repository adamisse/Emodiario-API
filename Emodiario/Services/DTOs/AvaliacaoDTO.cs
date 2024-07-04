using Emodiario.Utils.Enums;

namespace Emodiario.Services.DTOs;

public class AvaliacaoDTO
{
    public int Id { get; set; }
    public ValorAvaliacao Valor { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    public int IdCategoria { get; set; }
}