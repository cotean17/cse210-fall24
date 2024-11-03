using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    protected Goal(string name)
    {
        Name = name;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string DisplayStatus();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    public override void RecordEvent()
    {
        IsComplete = true;
        Console.WriteLine($"Goal completed: {Name}, earned {Points} points!");
    }

    public override string DisplayStatus()
    {
        return IsComplete ? $"[X] {Name}" : $"[ ] {Name}";
    }
}

public class EternalGoal : Goal
{
    private int totalPoints;

    public EternalGoal(string name, int points) : base(name)
    {
        Points = points;
        totalPoints = 0;
    }

    public override void RecordEvent()
    {
        totalPoints += Points;
        Console.WriteLine($"Goal recorded: {Name}, earned {Points} points! Total points: {totalPoints}");
    }

    public override string DisplayStatus()
    {
        return $"[ ] {Name} (Total Points: {totalPoints})";
    }
}

public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int targetCount, int points, int bonusPoints) : base(name)
    {
        this.targetCount = targetCount;
        Points = points;
        this.bonusPoints = bonusPoints;
        currentCount = 0;
    }

    public override void RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            Console.WriteLine($"Goal recorded: {Name}, earned {Points} points!");

            if (currentCount == targetCount)
            {
                IsComplete = true;
                Console.WriteLine($"Goal completed: {Name}, earned a bonus of {bonusPoints} points!");
            }
        }
        else
        {
            Console.WriteLine($"Goal {Name} is already complete.");
        }
    }

    public override string DisplayStatus()
    {
        return IsComplete ? $"[X] {Name} (Completed {currentCount}/{targetCount})" : $"[ ] {Name} (Completed {currentCount}/{targetCount})";
    }
}

public class GoalTracker
{
    private List<Goal> goals = new List<Goal>();
    public int TotalScore { get; private set; }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
        Console.WriteLine($"Added goal: {goal.Name}");
    }

    public void RecordGoalEvent(string goalName)
    {
        var goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            if (goal.IsComplete)
            {
                TotalScore += goal.Points; // Only add points if the goal is complete
            }
            else
            {
                TotalScore += goal.Points; // Add points for eternal and checklist goals
            }
            Console.WriteLine($"Total Score: {TotalScore}");
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GoalTracker tracker = new GoalTracker();

        tracker.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        tracker.AddGoal(new EternalGoal("Read Scriptures Daily", 100));
        tracker.AddGoal(new ChecklistGoal("Attend the Temple", 10, 50, 500));

        tracker.DisplayGoals();

        tracker.RecordGoalEvent("Read Scriptures Daily");
        tracker.RecordGoalEvent("Attend the Temple");
        tracker.RecordGoalEvent("Attend the Temple");

        tracker.DisplayGoals();
    }
}