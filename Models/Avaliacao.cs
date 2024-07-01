using Emodiario.Utils.Enums;

namespace Emodiario.Models;

public class Avaliacao
{
    public Avaliacao()
    {
    }

    public Avaliacao(ValorAvaliacao valor, string? descricao, int idUsuario, int idCategoria)
    {
        Valor = valor;
        Descricao = descricao;

        DataAtualizacao = DateTime.UtcNow;

        IdUsuario = idUsuario;
        IdCategoria = idCategoria;
    }

    public int Id { get; set; }
    public ValorAvaliacao Valor { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public Usuario? Usuario { get; set; }
    public int IdUsuario { get; set; }
    public Categoria? Categoria { get; set; }
    public int IdCategoria { get; set; }
}