using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class QuestionInfo
{
    public int level;
    public string id;
    public string question;
    public string answer1;    
    public string answer2;
    public string rightAnswer;

    public QuestionInfo() { }

    public QuestionInfo(int level, string id, string question, string answer1, string answer2)
    {
        this.level = level;
        this.id = id;
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;   
        this.rightAnswer = answer1;     
    }

    public void Shuffle(){
        this.rightAnswer = answer1;
        Random rnd = new Random();
        if(rnd.Next(6) % 2 == 0){
            this.answer1 = answer2;
            this.answer2 = rightAnswer;
        }
    }

    public String InfoString(){
        return $"Level:{level} - ID:{id} - Question:{question} - A1:{answer1} - A2:{answer2} - RA:{rightAnswer}";
    }
}
