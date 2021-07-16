using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Tools
{
    public class PasswordHasher
    {
        public static byte[] Hashing<T>(T model, string password, Func<T, string> saltSelector)
        {
            string salt = saltSelector(model);
            string result = salt.Substring(0, salt.Length / 2) + password + salt.Substring(salt.Length / 2);
            using(SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(result));
            }
        }
    }
}
