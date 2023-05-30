using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestionInfo
{
    public string level { get; }
    public string id { get; }
    public string question { get; }
    public string answer1 { set; get; }    
    public string answer2 { set; get; }
    public string rightAnswer { get; }

    public QuestionInfo() { }

    public QuestionInfo(string level, string id, string question, string answer1, string answer2)
    {
        this.level = level;
        this.id = id;
        this.question = question;
        this.rightAnswer = answer1;
        this.answer1 = answer1;
        this.answer2 = answer2;
        System.Random rnd = new System.Random();
        if(rnd.Next(6) % 2 == 0){
            this.answer1 = answer2;
            this.answer2 = rightAnswer;
        }
    }
}
