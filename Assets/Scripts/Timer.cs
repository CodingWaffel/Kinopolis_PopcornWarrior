using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] bool startOnAwake = true;
    [SerializeField] int time = 10;
    [SerializeField] string targetScene = "Menu";

    public Trigger onTimeOver;
    public float TimeLeft => this.timeLeft;
    public int MaxTime => this.time;
    float timeLeft;
    bool ticking = false;
    // Start is called before the first frame update
    void Awake()
    {
        this.timeLeft = this.time;
        this.onTimeOver += this.TimeUp;
        if(this.startOnAwake) this.StartTimer();
    }

    public void StartTimer(){
        if(this.ticking) return;

        this.ticking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.ticking) return;

        if(timeLeft >= 0){
            this.timeLeft -= Time.deltaTime;
            if(this.timeLeft <= 0 && this.onTimeOver != null) this.onTimeOver.Invoke();
        }
        
    }

    void TimeUp(){
        SceneChanger.instance.ChangeSceneToWithoutEndCapturing(this.targetScene);
    }
}
