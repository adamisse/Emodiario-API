using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace Emodiario.Services.Crypto;

public static class SenhaUtils
{
    private const int SaltSize = 16;
    private const int HashSize = 20;
    private const int Iterations = 10000;

    public static string HashPassword(string password)
    {
        var salt = new byte[SaltSize];
        new SecureRandom().NextBytes(salt);

        var pbkdf2 = new Pkcs5S2ParametersGenerator();
        pbkdf2.Init(Encoding.UTF8.GetBytes(password), salt, Iterations);
        var key = (KeyParameter)pbkdf2.GenerateDerivedMacParameters(HashSize * 8);

        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(key.GetKey(), 0, hashBytes, SaltSize, HashSize);

        return Convert.ToBase64String(hashBytes);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        var pbkdf2 = new Pkcs5S2ParametersGenerator();
        pbkdf2.Init(Encoding.UTF8.GetBytes(password), salt, Iterations);
        var key = (KeyParameter)pbkdf2.GenerateDerivedMacParameters(HashSize * 8);
        var keyBytes = key.GetKey();

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