static string SpecCharReplacer(string word, char[] from, char[] to) {

            if (from.Length == to.Length)
            {
                for (int i = 0; i < from.Length; i++)
                {
                    word = word.Replace(from[i], to[i]);
                }
                return word;
            }

            return "from and to character array must be the same lenght";
        }
        
