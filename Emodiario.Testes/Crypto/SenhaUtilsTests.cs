using Xunit;
using Emodiario.Services.Crypto;

namespace Emodiario.Testes.Crypto;

public class SenhaUtilsTests
{
    [Fact]
    public void HashPassword_ReturnsValidHash()
    {
        var password = "senha123";

        var hashedPassword = SenhaUtils.HashPassword(password);

        Assert.NotNull(hashedPassword);
        Assert.NotEmpty(hashedPassword);
        Assert.NotEqual(password, hashedPassword); // Verifica se a senha foi hashada
    }

    [Fact]
    public void VerifyPassword_WithCorrectPassword_ReturnsTrue()
    {
        var password = "senha123";
        var hashedPassword = SenhaUtils.HashPassword(password);

        var result = SenhaUtils.VerifyPassword(password, hashedPassword);

        Assert.True(result);
    }

    [Fact]
    public void VerifyPassword_WithIncorrectPassword_ReturnsFalse()
    {
        var password = "senha123";
        var incorrectPassword = "senha456";
        var hashedPassword = SenhaUtils.HashPassword(password);

        var result = SenhaUtils.VerifyPassword(incorrectPassword, hashedPassword);

        Assert.False(result);
    }
}