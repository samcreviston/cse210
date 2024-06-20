using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
            
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquareNumber(int num)
        {
            return num * num;
        }

        static void DisplayResult(string name, int sqNum)
        {
            Console.WriteLine($"{name}, the square of your number is {sqNum}");
        }


        
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int numSquared = SquareNumber(userNumber);

        DisplayResult(userName, numSquared);
    }
}