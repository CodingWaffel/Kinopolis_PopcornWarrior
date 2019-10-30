using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPool : MonoBehaviour
{

    public List<Impact> impacts;

    int iterator;

    void Start(){
        this.iterator = 0;
    }

    public Impact GetImpact(){
        Impact impact = this.impacts[this.iterator];
        this.iterator++;
        if(this.iterator >= this.impacts.Count) this.iterator = 0;

        return impact;
    }
}
