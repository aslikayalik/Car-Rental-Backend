using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public static class HashingHelper // bir şifre vericez, bize passwordHash ve passwordSalt üreticek. out ilr dışarı veriyo.
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) // iki tane parametre old. dan bu şekilde verdik sanırım, return le vermedik.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //neden out değil??????
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;

            }
        }

    }
}
