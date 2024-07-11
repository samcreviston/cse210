using System;
using System.Security.Cryptography.X509Certificates;

public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public void Display(string company, string job, int startYear, int endYear)
    {
        Console.WriteLine($"{job} ({company}) {startYear}-{endYear}");
    }
}

public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();
1
    public void Display()
    {
        Console.WriteLine($"Name: {_name}\nJobs:");

        foreach (Job job in _jobs)
        {
            job.Display(job._company, job._jobTitle, job._startYear, job._endYear);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        //creating Job instances
        Job job1 = new Job();

        job1._company = "Valve";
        job1._jobTitle = "Game Developer";
        job1._startYear = 2023;
        job1._endYear = 2024; 

         Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2019;
        job2._endYear = 2022; 


        Resume resume1 = new Resume();

        resume1._name = "Sam Creviston";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();
    }
}