using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager
{
    public const string GAME_DURATION = "GAMEDURATION";
    public const string SCORE_DURATION = "SCOREDURATION";
    public const string START_DURATION = "STARTDURATION";

    public static void SetGameDuration(int duration){
        PlayerPrefs.SetInt(GAME_DURATION, duration);
    }
    public static void SetScoreDuration(int duration){
        PlayerPrefs.SetInt(SCORE_DURATION, duration);
    }
    public static void SetStartDuration(int duration){
        PlayerPrefs.SetInt(START_DURATION, duration);
    }

    public static int GetGameDuration(){
        return PlayerPrefs.GetInt(GAME_DURATION);
    }
    public static int GetScoreDuration(){
        return PlayerPrefs.GetInt(SCORE_DURATION);
    }
    public static int GetStartDuration(){
        return PlayerPrefs.GetInt(START_DURATION);
    }
}
