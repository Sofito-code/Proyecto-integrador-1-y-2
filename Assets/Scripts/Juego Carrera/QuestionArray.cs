using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class QuestionArray
{
    public QuestionInfo[] questions;
    public QuestionArray(){ }

    public void ListShuffle(){ 
        foreach(QuestionInfo item in questions){
            item.Shuffle();            
        }
    }
}