using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionInfo
{
    public string level { get; }
    public string id { get; }
    public string question { get; }
    public string answer1 { get; }    
    public string answer2 { get; }

    public QuestionInfo() { }

    public QuestionInfo(string level, string id, string question, string answer1, string answer2)
    {
        this.level = level;
        this.id = id;
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
    }
}
