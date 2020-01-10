using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachoSpecial : PhysicalHitable
{   
    NachoSpawner nachoSpawner;

    void Start(){
        this.nachoSpawner = FindObjectOfType<NachoSpawner>();
        if(!this.nachoSpawner) Destroy(gameObject);
    }
    protected override void Hit(GameObject other)
    {
        if(other.tag != "Player") return;
        
        this.nachoSpawner.Activate();
        Score.Raise(this.Points);
        gameObject.SetActive(false);
    }


}
