using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class CardInfo
{
    public string level { get; }
    public string id { get; }
    public string question { get; }
    public string answer { get; }
    public int topic { get; }

    public CardInfo() { }

    public CardInfo(string level, string id, string question, string answer, int topic)
    {
        this.level = level;
        this.id = id;
        this.question = question;
        this.answer = answer;
        this.topic = topic;
    }
}
