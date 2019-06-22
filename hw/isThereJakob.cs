using System;

namespace isThereJakob_1 {
    class Program {

        static int HowManyStartsWithM(string[] names) {
            int total = 0;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower()[0] == 'm')
                {
                    total++;
                }
            }

            return total;
        }

        static bool IsThereJakob(string[] names) {
            bool answer = false;

            int i = 0;
            while (i < names.Length && names[i].ToLower() != "jakob")
            {
                i++;
            }
            answer = i < names.Length;
            return answer;
        }

        static void SplitByH(string[] names) {
            bool is_letter_H = false;
            string[] beforeH = new string[names.Length];
            string[] afterH = new string[names.Length];
            int before_index = 0;
            int after_index = 0;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i][0] == 'H' || names[i][0] == 'h')
                {
                    is_letter_H = true;
                }
                if (is_letter_H)
                {
                    beforeH[before_index] = names[i];
                    before_index++;
                }
                else
                {
                    afterH[after_index] = names[i];
                    after_index++;
                }
            }

            if (is_letter_H)
            {
                Console.WriteLine("Before H: ");
                for (int n = 0; n < beforeH.Length; n++)
                {
                    Console.WriteLine(beforeH[n]);
                }

                Console.WriteLine("After H: ");
                for (int n = 1; n < afterH.Length; n++)
                {
                    Console.WriteLine(afterH[n]);
                }
            }
        }


        static void Main(string[] args) {
            Console.WriteLine("How many names will be? ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] names = new string[n];

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Enter {i + 1} name: ");
                names[i] = Convert.ToString(Console.ReadLine());
            }
            Console.WriteLine("is there jakob? {0}", IsThereJakob(names));
            Console.WriteLine("Number of m letter names: {0}", HowManyStartsWithM(names));
            SplitByH(names);

            Console.ReadKey();
        }
    }
}
