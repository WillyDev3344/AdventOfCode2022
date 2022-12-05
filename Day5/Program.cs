using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
namespace Day5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<char> stack1 = new List<char> { 'M', 'F', 'C', 'W', 'T', 'D', 'L', 'B' };
            List<char> stack2 = new List<char> { 'L', 'B', 'N' };
            List<char> stack3 = new List<char> { 'V', 'L', 'T', 'H', 'C', 'J' };
            List<char> stack4 = new List<char> { 'W', 'J', 'P', 'S' };
            List<char> stack5 = new List<char> { 'R', 'L', 'T', 'F', 'C', 'S', 'Z' };
            List<char> stack6 = new List<char> { 'Z', 'N', 'H', 'B', 'G', 'D', 'W' };
            List<char> stack7 = new List<char> { 'N', 'C', 'G', 'V', 'P', 'S', 'M', 'F' };
            List<char> stack8 = new List<char> { 'Z', 'C', 'V', 'F', 'J', 'R', 'Q', 'W' };
            List<char> stack9 = new List<char> { 'H', 'L', 'M', 'P', 'R' };
            List<List<char>> stacks = new List<List<char>> { stack1, stack2, stack3, stack4, stack5, stack6, stack7, stack8, stack9 };

            string pattern = @"\d+\b";
            Regex rg = new Regex(pattern);

            string input = System.IO.File.ReadAllText(@"input.txt");
            MatchCollection guide = rg.Matches(input);

            List<int> instruction = new List<int>(3);
            List<char> crates = new List<char>();
            for (int i = 9; i < guide.Count(); i++)
            {
                instruction.Add(int.Parse(guide[i].Value));

                if ((i + 1) % 3 == 0)
                {
                    int crateNb = instruction[0];
                    int initialStack = instruction[1] - 1;
                    int finalStack = instruction[2] - 1;

                    for (int j = 0; j < crateNb; j++)
                    {
                        char crate = stacks[initialStack][j];

                        crates.Add(crate);
                    }
                    crates.Reverse();

                    foreach (char cr in crates.ToList())
                    {
                        stacks[initialStack].RemoveAt(0);
                        stacks[finalStack].Insert(0, cr);
                        crates.RemoveAt(0);
                    }

                    instruction.Clear();
                    crates.Clear();
                }
            }

            foreach (List<char> stack in stacks)
            {
                Console.Write(stack[0]);
            }
        }
    }
}