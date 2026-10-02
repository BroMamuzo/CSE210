using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou do not have any goals yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];

            Console.WriteLine(
                $"{i + 1}. {goal.GetStatus()} {goal.GetDetailsString()}");
        }
    }

    public void RecordEvent(int goalNumber)
    {
        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[goalNumber - 1];

        bool wasComplete = goal.IsComplete();

        int pointsEarned = goal.RecordEvent();

        if (pointsEarned == 0 && wasComplete)
        {
            Console.WriteLine("\nThis goal has already been completed.");
            return;
        }

        _score += pointsEarned;

        Console.WriteLine($"\nYou completed: {goal.GetName()}");
        Console.WriteLine($"+{pointsEarned} points!");

        if (goal is ChecklistGoal && goal.IsComplete() && !wasComplete)
        {
            Console.WriteLine("Congratulations! You completed the checklist goal!");
        }

        DisplayScore();
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
        Console.WriteLine($"Current Level: {GetLevel()}");
    }

    public int GetLevel()
    {
        return (_score / 500) + 1;
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("\nGoals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\nSave file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("\nThe save file is empty.");
            return;
        }

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            string[] parts = lines[i].Split('|');

            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(
                    new SimpleGoal(
                        name,
                        description,
                        points,
                        isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        name,
                        description,
                        points));
            }
            else if (goalType == "ChecklistGoal")
            {
                int targetAmount = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                _goals.Add(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        targetAmount,
                        bonus,
                        amountCompleted));
            }
        }

        Console.WriteLine("\nGoals loaded successfully.");
    }
}