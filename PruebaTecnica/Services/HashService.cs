using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PruebaTecnica.Dtos;
using System.Security.Cryptography;

namespace PruebaTecnica.Services
{
    public class HashService : IServiceHash
    {
        public ResultHashDto Hash(string input)
        {
            var sal = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(sal);
            }

            return Hash(input, sal);
        }

        public ResultHashDto Hash(string input, byte[] sal)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: sal,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10_000,
                numBytesRequested: 256 / 8
                ));

            return new ResultHashDto
            {
                Hash = hashed,
                Sal = sal
            };
        }
    }
}
