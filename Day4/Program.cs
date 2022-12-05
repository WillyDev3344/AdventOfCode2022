using System.Globalization;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"\d+\b";
            Regex rg = new Regex(pattern);

            string input = System.IO.File.ReadAllText(@"input.txt");
            MatchCollection pairs = rg.Matches(input);
            
            List<Int16> zones = new List<Int16>(4);
            int uselessPairs = 0;
            int overlappingPairs = 0;

            for (int i = 0; i < pairs.Count(); i++){
                Int16 number = Int16.Parse(pairs[i].Value);
                zones.Add(number);

                if ((i+1)%4 == 0){
                    if ( (zones[0] >= zones[2] && zones[1] <= zones[3]) || (zones[2] >= zones[0] && zones[3] <= zones[1]) ){
                        uselessPairs++; 
                        overlappingPairs++;
                    }
                    else if (Math.Max(zones[0], zones[2]) <= Math.Min(zones[1], zones[3])){
                            overlappingPairs++;
                        }
                zones.Clear();
                } 
            }

            Console.WriteLine(uselessPairs);
            Console.WriteLine(overlappingPairs);
        }
    }
}