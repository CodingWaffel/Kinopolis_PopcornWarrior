using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : KinematicMovement
{
    bool started;
    Vector2 start;

    Vector2 direction;
    public SinMovement(float speed, Vector2 target, Rigidbody2D rigidbody) : base(speed, target, rigidbody)
    {
        this.started = false;
    }

    public override bool Move()
    {
        if(!this.started){
            this.start = this.RigidBody.position;
            this.started = true;

            this.direction = (this.Target - this.start).normalized * this.Speed;
        }

        this.RigidBody.MovePosition(this.RigidBody.position + new Vector2(direction.x * Time.deltaTime, Mathf.Sin(Time.time) * direction.y * Time.deltaTime));

        return this.TargetReached();
        
    }

    public override bool TargetReached() => Vector3.Distance(this.Target, this.RigidBody.position) < .5f;
}
