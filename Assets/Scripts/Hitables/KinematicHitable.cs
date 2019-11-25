using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KinematicHitable : Hitable
{
    KinematicMovement[] movement;
    int iterator;
    public virtual Hitable Init(KinematicMovement[] movement){
        this.movement = movement;
        this.iterator = 0;
        return this;
    }

    protected override void OnUpdate(){
        if(this.movement[this.iterator].Move()){
            if(this.movement.Length > this.iterator + 1){
                this.iterator++;
            }
        }else{

        }
    }
}
