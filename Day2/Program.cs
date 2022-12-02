namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int score = 0;
            int actualScore = 0;
            Dictionary<string, int> values = new Dictionary<string, int>() {
                                                            {"A X", 4},
                                                            {"A Y", 8},
                                                            {"A Z", 3},
                                                            {"B X", 1},
                                                            {"B Y", 5},
                                                            {"B Z", 9},
                                                            {"C X", 7},
                                                            {"C Y", 2},
                                                            {"C Z", 6}};

            Dictionary<string, int> Actualvalues = new Dictionary<string, int>() {
                                                            {"A X", 3},
                                                            {"A Y", 4},
                                                            {"A Z", 8},
                                                            {"B X", 1},
                                                            {"B Y", 5},
                                                            {"B Z", 9},
                                                            {"C X", 2},
                                                            {"C Y", 6},
                                                            {"C Z", 7}};

            string[] input = System.IO.File.ReadAllLines(@"input.txt");
            foreach (string line in input)
            {
                // Part 1
                score += values[line];
                // Part 2
                actualScore += Actualvalues[line];
            }

            Console.WriteLine(score);
            Console.WriteLine(actualScore);
        }
    }

}