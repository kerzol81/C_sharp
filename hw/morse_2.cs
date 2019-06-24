using System;
using System.Text;
using System.IO;

namespace morse_2 {
    class Program {
        struct Morse {
            public char letter;
            public string word;
            public string code;

            public void DigestMorseCSV(string one_line) {
                string[] csv_chunks = one_line.Split(',');
                letter = Convert.ToChar(csv_chunks[0].ToLower());
                word = Convert.ToString(csv_chunks[1]);
                code = Convert.ToString(csv_chunks[2]);
            }
        }
        static void Beep(string code) {
            for (int i = 0; i < code.Length -1; i++)
            {
                if (code[i] == '.')
                {
                    Console.Beep(440, 150);
                }
                else
                    Console.Beep(440, 400);
            }
        }
        static string SearchCode(Morse[] morseTable, char c) {

            int i = 0;
            while (i < morseTable.Length && morseTable[i].letter != c)
            {
                i++;
            }
            if (i < morseTable.Length)
            {
                return morseTable[i].code;
            }
            return "no such code";
        }

        static string SearchWord(Morse[] morseTable, char c) {
            int i = 0;
            while (i < morseTable.Length && morseTable[i].letter != c)
            {
                i++;
            }
            if (i < morseTable.Length)
            {
                return morseTable[i].word;
            }
            return "unknown";
        }


        static void Main(string[] args) {
            StreamReader f = new StreamReader("morse.csv", Encoding.UTF8);
            string[] lines = f.ReadToEnd().Split('\n');
            Morse[] morseTable = new Morse[lines.Length - 1];

            for (int i = 0; i < morseTable.Length; i++)
            {
                morseTable[i].DigestMorseCSV(lines[i]);
            }

            char c;
            Console.WriteLine("\t* * * *  M O R S E  * * * * \t\texit: *");
            do
            {
                c = Console.ReadKey(true).KeyChar;
                Console.WriteLine("{0} \t\t\t {1} \t\t\t {2}", c, SearchWord(morseTable, c), SearchCode(morseTable, c));
                Beep(SearchCode(morseTable, c));
            } while (c != '*');

            Console.ReadKey();
        }
    }
}
