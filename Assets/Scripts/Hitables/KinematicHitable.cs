using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class KinematicHitable : Hitable
{
    [SerializeField] List<MovementFactory> movementFactories;
    protected KinematicMovement[] movement;
    protected int iterator;
    protected bool directionLeft;
    public virtual Hitable Init(float speed, Vector2 target, Rigidbody2D rigidbody){
        this.movement = this.movementFactories.ConvertAll(m => m.Create(target, rigidbody)).ToArray();
        this.iterator = 0;
        return this;
    }

    protected override void OnUpdate(){
        
    }

    private void FixedUpdate() {
        this.Move();
    }

    public virtual void Move(){
        if(this.movement[this.iterator].Move()){
            if(this.movement.Length > this.iterator + 1){
                this.iterator++;
            }
        }else{

        }
    }
}
