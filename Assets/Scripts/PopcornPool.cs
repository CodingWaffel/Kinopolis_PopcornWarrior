﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornPool : MonoBehaviour
{
    public List<PhysicalHitable> hitables;

    int iterator;

    void Start(){
        this.iterator = 0;
    }

    public PhysicalHitable GetHitable(){
        PhysicalHitable impact = this.hitables[this.iterator];
        this.iterator++;
        if(this.iterator >= this.hitables.Count) this.iterator = 0;

        return impact;
    }
}
