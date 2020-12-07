using System.Text;

namespace FileSyncer.Control
{
    static class Xor
    {
        private static readonly string key = "AABB";
        public static string Encrypt(string plain_password)
        {
            // https://stackoverflow.com/a/19297948
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < plain_password.Length; i++)
                s.Append((char)(plain_password[i] ^ key[(i % key.Length)]));
            string result = s.ToString();
            return result;
        }

        public static string Decrypt(string xored_password)
        {
            return Encrypt(xored_password);
        }
    }
}
