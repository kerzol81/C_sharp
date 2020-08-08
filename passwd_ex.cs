using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DB1
{
    static class PasswordCTRL
    {
        public static string Encode(string passord)
        {
            return BitConverter.ToString(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(passord))).Replace("-","").ToLower();
        }

        public static bool StrongPWD(string password)
        {
            if (password.Length > 7 && password.ToUpper() != password && password.ToLower() != password)
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (password.Contains(i.ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
