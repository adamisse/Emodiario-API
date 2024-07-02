namespace Emodiario.Models;

public class Categoria
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    public Usuario? Usuario { get; set; }
    public int IdUsuario { get; set; }
    public List<Avaliacao>? Avaliacoes { get; set; } = new List<Avaliacao>();
}