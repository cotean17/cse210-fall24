using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Sort Manager";
        job1._company = "Fedex";
        job1._startYear = 2017;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Production Manager";
        job2._company = "Rivian";
        job2._startYear = 2021;
        job2._endYear = 2023;

        Job job3 = new Job();
        job3._jobTitle = "Production and Data Analytic";
        job3._company = "Prudential";
        job3._startYear = 2023;
        job3._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Bradley MacKay";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();
    }
}