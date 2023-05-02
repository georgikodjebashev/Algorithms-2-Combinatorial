using System.Diagnostics.Metrics;

namespace algo2
{
    internal class Program
    {
        #region Vareiables 

        private static string[] elements;
        private static HashSet<string> permutation = new HashSet<string>();

        private static int k;
        private static string d;
        private static int n;
        private static string[] variations;
        private static bool[] used;

        private static string[] combinations;

        #endregion

        static void Main(string[] args)
        {
            /* Decoment to use GenCombinations()   {Recomend to add '2' for the comb number}
              
             Console.WriteLine("Input the elements:");
              elements = Console.ReadLine().Split();    
            Console.WriteLine("Input the combination number:");
              k = int.Parse(Console.ReadLine());
              combinations = new string[k];

              GenCombinations(0,0);
             */

            /* Decoment to use Variations()
             *
            Console.WriteLine("Input the elements:");
            elements = Console.ReadLine().Split();
            Console.WriteLine("Input the count of nums in the variations:");

            k = int.Parse(Console.ReadLine());
            variations = new string[k];
            used = new bool[elements.Length];

            Variations(0);
            */

            /* Decoment to use Binom()
             *
            Console.WriteLine("The row:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("The column:");
            k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n,k));
            */

            /* Decoment to use Permutate()
             
            Console.WriteLine("Input the element:");
            elements = Console.ReadLine().Split();
            Console.WriteLine("Input the number of permutations you need:");
            k = int.Parse(Console.ReadLine());
            used = new bool[elements.Length];

              Permute(0);
            */
        }

        #region Methods
        private static int Binom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return Binom(row - 1, col) + Binom(row - 1, col - 1);
        }

        // Variations
        private static void Variations(int idx)
        {
            if(idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ",variations));
                return;
            }

            for(int i = 0; i < elements.Length; i++)
            {
                used[i] = true;
                variations[idx] = elements[i];
                Variations(idx + 1);
                used[i] = false;
            }
        }
       
        // Combunations
        private static void GenCombinations(int idx, int elementsStartIdx) 
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIdx; i < elements.Length; i++) 
            {
                combinations[idx] = elements[i];
                GenCombinations(idx + 1, i + 1);
            }
        }

        // Shous the permutation 
        private static void Permute(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(idx + 1);
            var used = new HashSet<string>() { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++) 
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i);
                    Permute(idx + 1);
                    Swap(idx, i);

                    used.Add(elements[i]);
                }
            }
        }
        private static void Swap(int first, int second)
        {
            var temp = elements[first]; 
            elements[first] = elements[second];
            elements[second] = temp;
        }

        #endregion
    }
}



/* Un optimized version of Permute() 
  
        private static string[] permutations;
        private static bool[] used;
        private static string[] elements;

        private static void Permute(int idx)
        {
           
            if (idx >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }
            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i]) 
                {
                      used[i] = true;
                    permutations[idx] = elements[i];
                    Permute(idx + 1);
                    used[i] = false;
                }
            }
        
        }*/