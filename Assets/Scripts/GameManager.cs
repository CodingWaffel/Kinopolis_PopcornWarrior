using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Timer timer;
    void Awake()
    {
        Score.Reset();
        this.timer.time = PlayerPrefsManager.GetGameDuration();
        this.timer.StartTimer();
    }

    void Update() {
  
    }

    

}
