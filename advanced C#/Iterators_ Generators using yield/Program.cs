//Submission code 1202_CMPE2800_A02
//Chris Forest
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generators;

namespace chris_ica02_Generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 3, max = 11;
            Console.WriteLine("GenRange tests\n");
            {
                Console.WriteLine($"GenRange {min}, {max}");
                foreach (int item in Generators.GenRange(min, max))
                    Console.Write($"{item}, ");
                Console.WriteLine("\n");
            }

            {
                Console.WriteLine($"GenRange {max}");
                foreach (int item in Generators.GenRange(max))
                    Console.Write($"{item}, ");
                Console.WriteLine("\n");
            }

            {
                Console.WriteLine($"GenRange");
                foreach (int item in Generators.GenRange())
                    Console.Write($"{item}, ");
                Console.WriteLine("\n");
            }
            {
                Console.WriteLine("GenPass 5 chars long");
                foreach (int item in Generators.GenRange(5))
                    foreach (string pass in Generators.GenPass())
                    {
                        Console.Write($"{pass}, ");
                        break;//break infinte run of passwords
                    }
                //Generators.GenPass().Take(5);
                Console.WriteLine();
            }
            //{
            //    Console.WriteLine("GenPass take test");
            //    List<char> test = new List<char>();
            //    test.AddRange((IEnumerable<char>)Generators.GenPass().Take(5));
            //    Console.WriteLine($"{new string(test.ToArray())}");
            //    Console.WriteLine();
            //}
            {
                Console.WriteLine("\nShuffle list");
                foreach (int item in Generators.Shuffle(new List<int>() { 2, 4, 6, 8, 10 }))
                    Console.Write($"{item}, ");
                Console.WriteLine();

                Console.WriteLine("\nShuffle range");
                foreach (int item in Generators.Shuffle(Generators.GenRange(10, 25)))
                    Console.Write($"{item}, ");
                Console.WriteLine();
            }
            {
                Console.WriteLine("\nSuperSort of Shuffled Range");
                foreach (int item in Generators.SuperSort(Generators.Shuffle(Generators.GenRange(10, 25))))
                    Console.Write($"{item}, ");
                Console.WriteLine();
            }
            {
                Console.WriteLine("\nPullMax - original then PullMax");
                foreach (int item in Generators.GenRange(min, max).Concat(Generators.GenRange(min + 5, max + 5)))
                    Console.Write($"{item}, ");
                Console.WriteLine();
                foreach (int item in Generators.PullMax(Generators.GenRange(min, max).Concat(Generators.GenRange(min + 5, max + 5))))
                    Console.Write($"{item}, ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
