using System.Security.Cryptography.X509Certificates;

namespace AoC02
{
    internal class Program
    {



        static void Main(string[] args)
        {


            List<int[]> exampleList = new List<int[]>();
            exampleList.Add(new int[] { 7, 6, 4, 2, 1 });
            exampleList.Add(new int[] { 1, 2, 7, 8, 9 });
            exampleList.Add(new int[] { 9, 7, 6, 2, 1 });
            exampleList.Add(new int[] { 1, 3, 2, 4, 5 });
            exampleList.Add(new int[] { 8, 6, 4, 4, 1 });
            exampleList.Add(new int[] { 1, 3, 6, 7, 9 });

            Console.WriteLine("Second day of code");

            var inputData = File.ReadLines("input-data.txt");
            Console.WriteLine(inputData.Count());
            // Create list of reports
            List<int[]> reports = new List<int[]>();
            // Fill the list of reports with arrays containing reports
            foreach (var line in inputData)
            {
                string[] substrings = line.Split(' ');
                int[] levels = new int[substrings.Length];
                for (int i = 0; i < substrings.Length; i++)
                {
                    int number = int.Parse(substrings[i]);
                    levels[i] = number;
                }
                reports.Add(levels);
            }
            List<int[]> testList = reports.Slice(0, 10);

            int safeTests = 0;

            foreach (var test in reports)
            {
                if ((IsAscendingOrDescending(test)) && (IsDifferingCorrectly(test)))
                    safeTests++;
            }
            Console.WriteLine(safeTests);

        }




        // find which reports are safe
        // safe reports:
        // - all increasing or all decreasing
        // - two adjacent levels differ by at least 1 and at most 3
        // How many reports are safe?

        // Lets fail fast
        // methods for checking descending/ascending thing? IsAscendingOrDescending and IsDifferingCorrectly


        // controls the trend. might return false if two values also are matching.
        static bool IsAscendingOrDescending(int[] report)
        {
            bool[] trend = new bool[report.Count() - 1];
            for (int i = 0; i < report.Count(); i++)
            {
                if (i > 0)
                {
                    int delta = report[i - 1] - report[i];
                    // previous - current. If pos -> descending -> false. If neg -> ascending -> true.
                    if (delta < 0)
                    {
                        trend[i - 1] = true;
                    }
                    else
                    {
                        trend[i - 1] = false;
                    }
                }
            }

            if ((trend.Contains(true)) && (trend.Contains(false)))
            { return false; }


            return true;
        }



        static bool IsDifferingCorrectly(int[] report)
        {
            int sumCorrect = 0;
            bool isCorrect = false;
            for (int i = 1; i < report.Length; i++)
            {
                int diff = System.Math.Abs(report[i] - report[i - 1]);

                if (diff >= 1 && diff <= 3)
                { sumCorrect++; }
            }
            if (sumCorrect == (report.Length - 1))
            { isCorrect = true; }

            return isCorrect;
        }



        // fel resultat = 43

    }


}