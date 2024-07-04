using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace Emodiario.Services.Crypto;

public static class SenhaUtils
{
    private const int SaltSize = 16; // Tamanho do sal em bytes
    private const int HashSize = 20; // Tamanho do hash em bytes
    private const int Iterations = 10000; // Número de iterações de hashing

    public static string HashPassword(string password)
    {
        // Gerar um sal aleatório
        var salt = new byte[SaltSize];
        new SecureRandom().NextBytes(salt);

        // Gerar o hash da senha
        var pbkdf2 = new Pkcs5S2ParametersGenerator();
        pbkdf2.Init(Encoding.UTF8.GetBytes(password), salt, Iterations);
        var key = (KeyParameter)pbkdf2.GenerateDerivedMacParameters(HashSize * 8);

        // Combinar sal e hash
        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(key.GetKey(), 0, hashBytes, SaltSize, HashSize);

        // Converter para string base64
        return Convert.ToBase64String(hashBytes);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extrair sal e hash
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Gerar o hash da senha fornecida
        var pbkdf2 = new Pkcs5S2ParametersGenerator();
        pbkdf2.Init(Encoding.UTF8.GetBytes(password), salt, Iterations);
        var key = (KeyParameter)pbkdf2.GenerateDerivedMacParameters(HashSize * 8);
        var keyBytes = key.GetKey();

        // Comparar hash da senha fornecida com o hash armazenado
        for (int i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != keyBytes[i])
            {
                return false;
            }
        }

        return true;
    }
}