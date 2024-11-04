using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected DateTime Date { get; }
    protected int Minutes { get; }

    protected Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({Minutes} min) - " +
               $"Distance: {GetDistance():0.0} " +
               $"{(this is Swimming ? "km" : "miles")}, Speed: {GetSpeed():0.0} " +
               $"{(this is Swimming ? "kph" : "mph")}, Pace: {GetPace():0.0} min per " +
               $"{(this is Swimming ? "km" : "mile")}";
    }
}

public class Running : Activity
{
    private double DistanceMiles { get; }

    public Running(DateTime date, int minutes, double distanceMiles) : base(date, minutes)
    {
        DistanceMiles = distanceMiles;
    }

    public override double GetDistance() => DistanceMiles;

    public override double GetSpeed() => (DistanceMiles / Minutes) * 60;

    public override double GetPace() => Minutes / DistanceMiles;
}

public class Cycling : Activity
{
    private double SpeedMph { get; }

    public Cycling(DateTime date, int minutes, double speedMph) : base(date, minutes)
    {
        SpeedMph = speedMph;
    }

    public override double GetDistance() => (SpeedMph * Minutes) / 60;

    public override double GetSpeed() => SpeedMph;

    public override double GetPace() => 60 / SpeedMph;
}

public class Swimming : Activity
{
    private int Laps { get; }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance() => (Laps * 50) / 1000.0;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 15.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
