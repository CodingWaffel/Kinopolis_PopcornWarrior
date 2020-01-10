using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Timer : MonoBehaviour
{
    public int time = 10;
    [SerializeField] string targetScene = "Menu";

    public Trigger onTimeOver;
    public float TimeLeft => this.timeLeft;
    public int MaxTime => this.time;
    float timeLeft;
    bool ticking = false;
    List<(float, System.Action)> timeEvents;
    // Start is called before the first frame update
    void Awake()
    {
        this.timeEvents = new List<(float, System.Action)>();
    }

    public void StartTimer(){
        if(this.ticking) return;
        this.timeLeft = this.time;
        this.onTimeOver += this.TimeUp;
        this.ticking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.ticking) return;

        if(timeLeft >= 0){
            this.timeLeft -= Time.deltaTime;
            for(int i = 0; i < this.timeEvents.Count; i++){
                if(this.CheckTimeEvent(this.timeEvents[i].Item1, this.timeEvents[i].Item2, this.timeLeft)){
                    this.timeEvents.RemoveAt(i);
                }
            }
            if(this.timeLeft <= 0 && this.onTimeOver != null) this.onTimeOver.Invoke();
        }
        
    }

    void TimeUp(){
        SceneChanger.instance.ChangeSceneTo(this.targetScene);
    }

    public void RegisterTimeEvent(float time, System.Action resolveAction){
        this.timeEvents.Add((time, resolveAction));
    }

    bool CheckTimeEvent(float time, System.Action resolveAction, float currentTime){
        if(time >= currentTime){
            resolveAction();
            return true;
        }
        return false;
    }
}
