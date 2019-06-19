static string SpecCharReplacer(string word, char[] from, char[] to) {

            if (from.Length == to.Length)
            {
                for (int i = 0; i < from.Length; i++)
                {
                    word = word.Replace(from[i], to[i]);
                }
                return word;
            }

            return "[-] Error, The character arrays must be the same lenght";
        }
        
/*
TEST:
static void Main(string[] args) {

            char[] from = { 'á', 'é', 'ó' };
            char[] to = { 'a', 'e', 'o' };

            Console.Write(SpecCharReplacer("áááééé", from, to));

            Console.ReadKey();
        }
*/
