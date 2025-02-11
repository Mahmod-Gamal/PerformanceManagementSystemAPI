using PerformanceManagementSystem.Application.Interfaces.Identity;
using System.Security.Cryptography;
using System.Text;

namespace PerformanceManagementSystem.Infrastructure.Identity
{
    public class PasswordManager : IPasswordManager
    {
        private const string _EncryptionKey = "P56fF87*+$pzxtre";
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool Verfiy(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public string GenerateRandomOTP()
        {
            int length = 8;
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string digitChars = "0123456789";
            const string specialChars = "!@#$%^&*";
            const string allChars = upperChars + lowerChars + digitChars + specialChars;
            char[] otp = new char[length];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            otp[0] = GetRandomChar(upperChars, rng);
            otp[1] = GetRandomChar(lowerChars, rng);
            otp[2] = GetRandomChar(digitChars, rng);
            otp[3] = GetRandomChar(specialChars, rng);
            for (int i = 4; i < length; i++)
            {
                otp[i] = GetRandomChar(allChars, rng);
            }
            return new string(otp.OrderBy(_ => GetRandomInt(rng)).ToArray());
        }

        public string EncodeOTT(string username, string OTP)
        {
            string combinedData = $"{username}:{OTP}";
            return Encrypt(combinedData);
        }

        public (string username, string OTP) DecodeOTT(string OTT)
        {
            string decryptedData = Decrypt(OTT);
            string[] parts = decryptedData.Split(':');

            if (parts.Length == 2)
                return (parts[0], parts[1]);

            throw new Exception("Invalid OTT format");
        }

        private string Encrypt(string plainText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_EncryptionKey);
            using Aes aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = new byte[16]; // Zero IV (for simplicity)

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(encryptedBytes);
        }

        private string Decrypt(string cipherText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_EncryptionKey);
            using Aes aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = new byte[16];

            using var decryptor = aes.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            byte[] plainBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }

        private char GetRandomChar(string characterSet, RandomNumberGenerator rng)
        {
            byte[] randomByte = new byte[1];
            rng.GetBytes(randomByte);
            return characterSet[randomByte[0] % characterSet.Length];
        }

        private int GetRandomInt(RandomNumberGenerator rng)
        {
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            return BitConverter.ToInt32(randomBytes, 0);
        }

    }
}
