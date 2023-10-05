using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class CardInfo
{
    public int level;
    public string id;
    public string question;
    public string answer;
    public int topic;

    public CardInfo() { }

    public CardInfo(int level, string id, string question, string answer, int topic)
    {
        this.level = level;
        this.id = id;
        this.question = question;
        this.answer = answer;
        this.topic = topic;
    }
}
