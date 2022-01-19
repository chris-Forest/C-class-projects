//Submission code 1202_CMPE2800_A04
//Chris Forest

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace chris_ica04_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //part A******************************************************
            List<string> sourcestrings = new List<string>(
                new string[] { "Caballo", "Gato", "Perro", "Conejo", "Tortuga", "Cangrejo" });
                       
            //#1
            var sum = sourcestrings.Where(s => s.Sum(c=>c) < 600);
            foreach(var word in sum)
            {
                Console.WriteLine(word);
            }
            //#2
            foreach (var word in sum)
            {
                Console.WriteLine("{ " + $"Str= {word}, Sum= {word.Sum(c => c)}" + " }");
            }
            
            //#3
            Console.WriteLine();
            var rev = sourcestrings.Where(s => s.Sum(c => c) < 600);
            var strDESC = from ss in rev
                          orderby ss descending
                          select ss;
            foreach (var word in strDESC)
            {
                Console.WriteLine("{ " + $"Str= {word}, Sum= {word.Sum(c => c)}" + " }");
            }
            //part B**************************************************
            Console.WriteLine("\nPart B**********************************");

            //needs adjustment?
            var str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "junk.txt");
            var read = File.ReadAllText(str).Split('\n', '\r');
            //Console.WriteLine(rd);           

            // Use Split() on the read in string and use it for the datasource of you LINQ, 
            //then use Trim() in your where clause and your select. 
            //where x > 4 morphs to where word.Trim().length > N
            var trim = (from tm in read where tm.Trim().Length>0 select tm.Trim());

            //to a collection with sum orderby key
            var collection = from n in trim group n by n.Sum(c => c) into q orderby q.Key select q;

            // display lowest values
            Console.WriteLine($"Lowest ascii sum: {collection.First().Key}");
            Console.WriteLine($"Lowest string: {(from c in collection.First() orderby c select c).First()}");

            // display highest values
            Console.WriteLine($"highest ascii sum: {collection.Last().Key}");
            Console.Write($"highest string: {(from c in collection.Last() orderby c select c).Last()}/");
            //linq var
            var strg = (from c in collection.Last() orderby c select c).Last();
            Console.WriteLine($"{string.Join("",from cr in strg orderby cr select cr)}");

            //get biggest count and sum
            var biggest = (from n in collection orderby n.Count() select n);
            Console.Write($"biggest collection count: {biggest.Last().Count()} - ");
            Console.WriteLine($"ascii Sum : {biggest.Last().Key}");

            Console.ReadKey();
        }
    }
}
