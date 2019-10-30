using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{

    public static Trigger<int> onScoreChanged;
    static int score;
    public static int currentScore => score;
    static Score(){
        score = 0;
    }

    public static void Raise(int value){
        score += value;
        if(onScoreChanged != null) onScoreChanged.Invoke(score);
    }

    public static void Lower(int value){
        score -= value;
        if(onScoreChanged != null) onScoreChanged.Invoke(score);
    }

    public static void Reset(){
        score = 0;
        if(onScoreChanged != null) onScoreChanged.Invoke(score);
    }

    
    
}
