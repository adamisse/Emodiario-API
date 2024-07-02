using Emodiario.Utils.Enums;

namespace Emodiario.Models;

public class Avaliacao
{
    public Avaliacao()
    {
    }

    public Avaliacao(ValorAvaliacao valor, string? descricao, DateTime dataAtualizacao, int idCategoria)
    {
        Valor = valor;
        Descricao = descricao;

        DataAtualizacao = dataAtualizacao;

        IdCategoria = idCategoria;
    }

    public int Id { get; set; }
    public ValorAvaliacao Valor { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public Categoria? Categoria { get; set; }
    public int IdCategoria { get; set; }
}