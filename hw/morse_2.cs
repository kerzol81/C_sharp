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
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '.')
                {
                    Console.Beep(440, 150);
                }
                else
                    Console.Beep(440, 300);
            }
        }
        static string Search(Morse[] morseTable, char c) {

            int i = 0;
            while (i < morseTable.Length && morseTable[i].letter != c)
            {
                i++;
            }
            if (i < morseTable.Length)
            {
                return morseTable[i].code;
            }
            return "";
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
            Console.WriteLine("* * * * M O R S E * * * * \t\texit: *");
            do
            {
                c = Console.ReadKey().KeyChar;
                Console.Write("|");
                Beep(Search(morseTable, c));
            } while (c != '*');

            Console.ReadKey();
        }
    }
}
