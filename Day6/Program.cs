using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Day6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"input.txt");
            List<char> buffer = new List<char>(4);
            int index = 0;

            for(int i = 0; i < input.Length && index == 0; i++){
                buffer.Add(input[i]);

                if (buffer.Count == 14){
                    if (buffer.Distinct().Count() == 14) index = i + 1;
                    buffer.Clear();
                    i -= 13;
                }
            }
            Console.WriteLine(index);

        }
    }
}
