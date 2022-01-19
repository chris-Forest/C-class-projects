//Submission code 1202_CMPE2800_A02
//Chris Forest
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generators
{
    public class Generators
    {
        private static Random rdm = new Random();

        public static IEnumerable<int> GenRange(int low,int high)
        {
            for (int i = 0; i < high; i++)
            {
                yield return i;
            }
            yield break;
        }
        public static IEnumerable<int> GenRange(int high)
        {
            return GenRange(0, high);
        }
        public static IEnumerable<int> GenRange()
        {
            return GenRange(0, 1000);
        }

        //genPass//use string
        public static IEnumerable<string> GenPass()
        {
            string temp = " ";
            while (true)
            {
                temp = "";
                for (int i = 0; i < 5; i++)
                {
                   temp+= (char)rdm.Next('A', 'Z' + 1);
                }
                yield return temp;
            }  
        }
        //shuffle
        //like a normal fisher yates but you use a swap function you create inside the method 
        //to swap the indexes and then yield return the swapped index you were on
        
        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> array)
        {
            List<T> lst = array.ToList();
            int m = array.Count();

            T swap(int lft, int rgt)
            {
                T temp = lst[lft];
                lst[lft] = lst[rgt];
                lst[rgt] = temp;
                return temp;
            }

            for (int i = 0; i < m; i++)
            {
                int r = rdm.Next(i, m);
                yield return lst[i]= swap(r, i);
            }
        }

        //super sort(fix or adjust if needed)
        public static IEnumerable<T> SuperSort<T>(IEnumerable<T> source) where T :IComparable
        {
            List<T> arr = source.ToList();
            int n = arr.Count();

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j].CompareTo(arr[min_idx])==-1)
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                
                T temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
                yield return temp;
            }
        }

        //pullmax(fix or adjust if needed)
        public static IEnumerable<T>PullMax<T>(IEnumerable<T> source)
        {
            bool first=true;
            T last = default(T);
            //track firt one with bool
            foreach (T item in source.OrderByDescending(s => s))
            {
                if(first)
                {
                    first = false;
                    yield return item;
                    last = item;
                    
                    continue;
                }
                
                //check for dups, but how?
                if (item.Equals(last))
                {
                    last = item;
                    
                    continue;
                }
                last=item;
                yield return item;
            }
        }
    }
}
