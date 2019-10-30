using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] NachoSpawner nachoSpawner;
    // Start is called before the first frame update
    void Awake()
    {
        Score.Reset();
    }

    void Update() {
        if(!this.nachoSpawner.Active && this.timer.TimeLeft <= this.nachoSpawner.Duration){
            this.nachoSpawner.Activate();
        }    
    }

    

}
