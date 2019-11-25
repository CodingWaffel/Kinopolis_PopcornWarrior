using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicHitablePool : MonoBehaviour
{
    public List<KinematicHitable> hitables;

    int iterator;

    void Start(){
        this.iterator = 0;
    }

    public KinematicHitable GetHitable(){
        KinematicHitable impact = this.hitables[this.iterator];
        this.iterator++;
        if(this.iterator >= this.hitables.Count) this.iterator = 0;

        return impact;
    }
}
