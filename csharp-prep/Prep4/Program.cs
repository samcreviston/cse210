using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            string strInt = Console.ReadLine();
            number = int.Parse(strInt);

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        //Calculate sum
        int sum = numbers.Sum();

        //Calculate average
        double average = numbers.Average();

        //Find the max
        int max = numbers.Max();

        //Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}