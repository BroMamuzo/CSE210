using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What is something new I learned today?",
        "What is one thing I am grateful for today?",
        "What was the strongest emotion I felt today?",
        "What is one goal I want to accomplish tomorrow?",
        "What is something that made me smile today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}