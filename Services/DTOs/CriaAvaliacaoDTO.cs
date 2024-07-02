using Emodiario.Utils.Enums;

namespace Emodiario.Services.DTOs;

public class CriaAvaliacaoDTO
{
    public ValorAvaliacao Valor { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public int IdUsuario { get; set; }
    public int IdCategoria { get; set; }
}