using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationManager.Tools.SecurityTools
{
    public static class PasswordHasher
    {
        public static byte[] HashMe(string passwordIn)
        {
            byte[] data = Encoding.UTF8.GetBytes(passwordIn);
            byte[] result;

            SHA512 shaM = new SHA512Managed();

            result = shaM.ComputeHash(data);
            return result;
                }
    }
}
