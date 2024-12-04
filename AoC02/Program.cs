namespace AoC02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Second day of code");

            var inputData = File.ReadLines("input-data.txt");
            Console.WriteLine(inputData.Count());

            List<int[]> reports = new List<int[]>();

            foreach (var line in inputData)
            {
                string[] substrings = line.Split(' ');
                int[] numberArray = new int[substrings.Length];
                for (int i = 0; i < substrings.Length; i++)
                {
                    int number = int.Parse(substrings[i]);
                    numberArray[i] = number;
                }
                reports.Add(numberArray);
            }







        }
    }
}
