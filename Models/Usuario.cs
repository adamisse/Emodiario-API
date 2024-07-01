using Emodiario.Services.Crypto;

namespace Emodiario.Models;

public class Usuario
{
    public Usuario()
    {
    }

    public Usuario(string nome, string email, string senha, string telefone)
    {
        Nome = nome;
        Email = email;
        SenhaHash = SenhaUtils.HashPassword(senha);
        Telefone = telefone;
    }

    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? SenhaHash { get; set; }
    public string? Telefone { get; set; }
    public List<Avaliacao>? Avaliacoes { get; set; } = new List<Avaliacao>();
}