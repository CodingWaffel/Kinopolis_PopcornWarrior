using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GestureManager gesturePrefab;
    void Awake()
    {
        Score.Reset();
        this.timer.time = PlayerPrefsManager.GetGameDuration();
        this.timer.RegisterTimeEvent(this.timer.time * .5f, this.InitGesture);
        this.timer.StartTimer();
    }

    void Update() {
  
    }

    void InitGesture(){
        Instantiate(this.gesturePrefab);
    }

    

}
