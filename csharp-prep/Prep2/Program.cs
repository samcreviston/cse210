using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        //recieve grade
        Console.Write("What is your grade percentage? ");
        string strGrade = Console.ReadLine();
        int grade = int.Parse(strGrade);

        //prep for writing letter
        Console.WriteLine();
        string letter = "";

        //determin and assign letter to variable
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //print letter grade
        Console.WriteLine($"Your letter grade: {letter}");


        //determine congragulatory sentence or encouraging sentence
        if (grade >=70)
        {
            Console.Write("Well done, keep it up!");
        }
        else{
            Console.Write("Better luck next time!");
        }
    }
}