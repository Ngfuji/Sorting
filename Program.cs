using System.Diagnostics;
class BowGowSort
{
    static Random rand = new Random();

    static void Main()
    {
        int[] numbers = File.ReadAllLines("numbers.txt")
                            .Select(int.Parse)
                            .ToArray();

        Console.WriteLine("Raw Numbers: " + string.Join(", ", numbers));

        Stopwatch stopwatch = Stopwatch.StartNew();

        BogoSort(numbers);

        Console.WriteLine("Ordered Numbers: " + string.Join(", ", numbers));

        Console.WriteLine($"Time Taken: {stopwatch.Elapsed.TotalSeconds:F6} seconds");
    }

    static void BogoSort(int[] array)
    {
        while (!IsSorted(array))
        {
            Shuffle(array);
        }
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
                return false;
        }
        return true;
    }

    static void Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = rand.Next(array.Length);
            (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
        }
    }
}
