using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        Job job1 = new Job();
        job1._companyName = "Software Engineer";
        job1._jobTitle = "Microsoft";
        job1._startYear = "2020";
        job1._endYear = "2022";
        Job job2 = new Job();
        job2._companyName = "Data Scientist";
        job2._jobTitle = "Google";
        job2._startYear = "2018";
        job2._endYear = "2020";

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._name = "James Adhiambo";
        myResume.DisplayResume();
        
    }
}