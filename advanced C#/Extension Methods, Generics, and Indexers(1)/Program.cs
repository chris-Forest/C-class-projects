//submission code 1202_CMPE2800_A01
//Chris forest

//Skill testing question: 
//what assumptions are we making about the types that will 
//participate as keys and values?

//Answer: when generic extension method, the method itself will deduce from 
//when it was called and use the specifieid type. 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chris_ica01_generics
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("\n=======start of catigorize test code========");
            List<int> iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            Console.WriteLine("default defined type method");
            foreach (KeyValuePair<int, int> scan in iNums.InitCategorize())
                Console.WriteLine($"{scan.Key:d3} x {scan.Value:d2}");

            //generic extension method test
            List<string> names = new List<string>(new string[]
            {"Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });

            Console.WriteLine("\ngeneric adjusted method");
            foreach (KeyValuePair<string, int> scan in names.TCategorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d2}");

            //generic collection method testing
            LinkedList<char> llfloats = new LinkedList<char>();
            Random _rnd = new Random();
            Console.WriteLine("\ngeneric catigorize method");

            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            foreach (KeyValuePair<char, int> scan in llfloats.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d2}");
            Console.Write("\n");

            string TestString = "This is the test string, do not panic!";

            foreach (KeyValuePair<char, int> scan in TestString.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d2}");

            //ramping freq test code*****************************************
            Console.WriteLine("\nfrequency ramping tests");
            Console.WriteLine("\nfrequency ramping test 1: 112123123412345");
            string TestString2 = "112123123412345";
            foreach (KeyValuePair<char, int> scan in TestString2.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d2}");

            Console.WriteLine("\nfrequency ramping test 2: 554543543254321");
            string TestString3 = "554543543254321";
            foreach (KeyValuePair<char, int> scan in TestString3.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");

            Console.WriteLine("\nfrequency ramping test 3: 123234234523456654325432432321");
            string TestString4 = "123234234523456654325432432321";
            foreach (KeyValuePair<char, int> scan in TestString4.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d2}");

            //ref test code*******************************
            Console.WriteLine("\nref test class tests ints 1-10");
            List<refTest> refsInts = new List<refTest>();

            while (refsInts.Count < 100)
            {
                refTest refTest = new refTest(random.Next(1, 11));
                refsInts.Add(refTest);
            }
            foreach (KeyValuePair<refTest, int> scan in refsInts.Categorize())
                Console.WriteLine($"num: {scan.Key.x}, Value: {scan.Value:d2}");


            Console.WriteLine("=======end of catigorise test code========");

            //more test code for my extension methods
            //modal test code
            //5 and 6 tie for frequency
            {
                int[] modal = new int[] { 6, 6, 4, 5, 2, 5, 6, 2, 1, 8, 2, 5, 2, 3, 4 }; // No tie, 2 wins
                Console.WriteLine($"\nmodal test code for not tie picking last instance 2 ?: {modal.Modal()}");
            }
            {
                int[] modal = new int[] { 6, 6, 4, 5, 2, 5, 6, 2, 6, 8, 2, 5, 2, 3, 4 }; // ties with 6, 2 but 2 is last
                Console.WriteLine($"\nmodal test code for tie picking last instance 2 ?: {modal.Modal()}");
            }

            int[] modalA = new int[] { 5, 7, 2, 2, 4, 9, 1 };
            Console.WriteLine($"Modal(no tie) : {modalA.Modal()}");
            Console.WriteLine("\n=======end of modal test code========");
            Console.WriteLine("\n=======start of shuffle test code========");

            //shuffle test code
            int mill = 1_000_000;
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] stats = new int[10];

            int t = array.Sum();
            decimal ct = t * mill / array.Count();
            Console.WriteLine("ideal index value is " + ct);
            Console.WriteLine("\nshuffle test code");

            for (int j = 0; j < mill; j++)// million itterations wanted
            {
                int[] temp;
                temp = array.Shuffle().ToArray();

                for (int i = 0; i < temp.Length; i++)//update stats here
                {
                    stats[i] += temp[i];
                    //Console.Write($"{array[i]} ");                  
                }
            }

            //int diff = (5500000 - stats[0]) / 5500000 * 100;
            //int diff = 5500000 - stats[0];
            //Console.WriteLine("diff is: "+diff);
            //decimal p =diff/5500000m;
            //Console.WriteLine(p);
            //Console.WriteLine($"{stats[0]}: percent dif: {p:p4}"); //displays total stats per index spot

            for (int i = 0; i < stats.Length; i++)//get % totals
            {
                decimal diff = ct - stats[i];
                decimal p = (diff / ct);
                //displays total stats per index spot
                Console.WriteLine($"{stats[i]}: percent dif: {p:p4}:");
            }

            Console.WriteLine("\n=======end of shuffle test code========");
            Console.WriteLine("\n=======start of frame test code========");
            //frame test code
            List<int> junk = new List<int>(new int[] { 4, 5, 2, 5, 6, 2, 1, 8, -2 });
            junk.Sort();
            Console.WriteLine("\nsorted");
            for (int i = 0; i < junk.Count; i++)
            {
                Console.Write($"{junk[i]} ");
            }
            Console.WriteLine($"\n\nframe method test code\n{junk.Frame().low}, {junk.Frame().high}");

            //generic class test code****
            SuperStack<string> myStack = new SuperStack<string>();
            myStack.Push("this");
            myStack.Push("is");
            myStack.Push("what");
            myStack.Push("this");
            myStack.Push("is");

            Console.WriteLine($"\ngeneric class test\nCat element 1 : {myStack[1]}");
            Console.WriteLine($"Cat count of 'is' : {myStack["is"]}");

            Console.WriteLine($"\nout of range checks");
            try
            {
                Console.WriteLine($"\ngeneric class test\nCat element 1 : {myStack[-1]}");
                Console.WriteLine($"\ngeneric class test\nCat element 1 : {myStack[7]}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
    static class MyExtensions
    {
        static Random random = new Random();

        //inital extension method
        public static Dictionary<int, int> InitCategorize(this List<int> sourcelist)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();

            foreach (int item in sourcelist)
            {
                if (!pairs.ContainsKey(item))
                {
                    pairs.Add(item, 1);
                }
                else
                {
                    pairs[item] += 1;
                }
            }
            pairs = pairs.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
            return pairs;
        }

        //generic operation lists
        public static Dictionary<T, int> TCategorize<T>(this List<T> sourcelist) where T : IComparable
        {
            Dictionary<T, int> pairs = new Dictionary<T, int>();

            foreach (T item in sourcelist)
            {
                if (!pairs.ContainsKey(item))
                {
                    pairs.Add(item, 1);
                }
                else
                {
                    pairs[item] += 1;
                }
            }
            pairs = pairs.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
            return pairs;
        }

        //generic collections
        public static Dictionary<K, int> Categorize<K>(this IEnumerable<K> sourcelist) 
        {
            Dictionary<K, int> pairs = new Dictionary<K, int>();

            foreach (K item in sourcelist)
            {
                if (!pairs.ContainsKey(item))
                {
                    pairs.Add(item, 1);
                }
                else
                {
                    pairs[item] += 1;
                }
            }
            pairs = pairs.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
            return pairs;
        }

        public static T Modal<T>(this IEnumerable<T> sourcelist) where T : IComparable
        {
            //Dictionary<T, int> pairs = new Dictionary<T, int>();
            List<T> tempList = sourcelist.ToList();
            int max = 0;
            T foundNumber = default;
            T currentNumber;

            for (int i = 0; i < tempList.Count(); i++)
            {
                currentNumber = tempList[i];
                int occurs = 1;
                for (int j = 0; j < tempList.Count(); j++)
                {
                    if (currentNumber.Equals(tempList[j]))
                        occurs++;

                }
                if (occurs > max)
                {
                    foundNumber = currentNumber;
                    max = occurs;
                }
                if (occurs == max)
                {
                    foundNumber = currentNumber;
                    max = occurs;
                }
            }
            return foundNumber;

            //for (int i = sourcelist.Count() - 1; i >= 0; i--)
            //{
            //    if (!pairs.ContainsKey(sourcelist.ElementAt(i)))
            //    {
            //        pairs.Add(sourcelist.ElementAt(i), 1);
            //    }
            //    else
            //    {
            //        pairs[sourcelist.ElementAt(i)] += 1;
            //    }
            //}
            ////pairs = pairs.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            //foreach (KeyValuePair<T, int> item in pairs)//sourcelist
            //{
            //    if (pairs.ContainsKey(mode))
            //    {
            //        if (pairs[item.Key] >= pairs[mode])
            //        {
            //            mode = item.Key;
            //        }
            //    }
            //    else
            //    {
            //        mode = item.Key;
            //    }
            //}
            //return mode;
        }

        //shuffle method
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> array) where T : IComparable
        {
            List<T> lst = array.ToList();
            int m = array.Count();

            for (int i = 0; i < m; i++)
            {
                int r = random.Next(i, m);
                T t = lst[r];
                lst[r] = lst[i];
                lst[i] = t;
            }
            return lst;
        }

        //tuple
        public static (T low, T high) Frame<T>(this IEnumerable<T> sourcelist) where T : IComparable
        {
            Dictionary<T, int> pairs = new Dictionary<T, int>();

            pairs = sourcelist.Categorize();

            //foreach (T item in sourcelist)
            //{
            //    if (!pairs.ContainsKey(item))
            //    {
            //        pairs.Add(item, 1);
            //    }
            //    else
            //    {
            //        pairs[item] += 1;
            //    }
            //}
            //pairs = pairs.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
            //var max = pairs.Last().Key;
            //var min = pairs.First().Key;
            return (pairs.Keys.Last(), pairs.Keys.First());
        }
    }
    public class refTest : IComparable
    {
        public int x { get; set; }
        public refTest(int v)
        {
            x = v;
        }
        public int CompareTo(object obj)
        {
            if (!(obj is refTest arg))
                throw new ArgumentException("no goo number");
            return x.CompareTo(arg.x);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is refTest arg))
                return false;
            return x.Equals(arg.x);
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }

    public class SuperStack<T> : Stack<T>//change name of index<T>
    {
        public T this[int index]
        {
            get
            {
                Dictionary<T, int> dic = this.Categorize();

                if (index < 0 || index >= this.Count())
                    throw new IndexOutOfRangeException("index not within range");
                return dic.ElementAt(index).Key;
            }
        }

        public int this[T index]
        {
            get
            {
                Dictionary<T, int> dic = this.Categorize();
                if (!dic.ContainsKey(index))
                {
                    throw new ArgumentException("key doesnt exist");
                }
                else
                    return dic[index];
                //int counter=0;
                //if (this.Contains(index) == false)
                //    throw new ArgumentException("word doesnt exist");

                //for (int i = 0; i < this.Count(); i++)
                //{
                //    if(this.ElementAt(i).Equals( index))
                //    {
                //        counter++;
                //    }
                //}
                //return counter;
            }
        }
    }
}
