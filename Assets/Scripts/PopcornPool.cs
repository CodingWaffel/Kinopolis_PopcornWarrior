using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornPool : MonoBehaviour
{
    public List<Hitable> hitables;

    int iterator;

    void Start(){
        this.iterator = 0;
    }

    public Hitable GetHitable(){
        Hitable impact = this.hitables[this.iterator];
        this.iterator++;
        if(this.iterator >= this.hitables.Count) this.iterator = 0;

        return impact;
    }
}
