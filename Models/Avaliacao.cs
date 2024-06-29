using Emodiario.Utils.Enums;

namespace Emodiario.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public ValorAvaliacao Valor { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Usuario? Usuario { get; set; }
        public int IdUsuario { get; set; }
        public Categoria? Categoria { get; set; }
        public int IdCategoria { get; set; }
    }
}