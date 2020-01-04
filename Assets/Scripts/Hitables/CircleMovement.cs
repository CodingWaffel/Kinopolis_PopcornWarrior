using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : KinematicMovement
{
    float radius;

    Vector2 mid;
    bool started, inCircle;
    float angle;
    float circularSpeed;
    public CircleMovement(float speed, Vector2 target, Rigidbody2D rigidbody, float radius) : base(speed, target, rigidbody)
    {
        this.started = false;
        this.radius = radius;
        this.mid = target;
    }

    public override bool Move()
    {
        //X2 = R2 - y2,  Y2 = R2 - X2
        if(!this.started){
            this.angle = 0;
            this.circularSpeed = (2*Mathf.PI) / this.Speed;
            this.started = true;
            this.inCircle = false;
        }

        angle += circularSpeed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
        float x = mid.x + Mathf.Cos(angle)*radius;
        float y = mid.y + Mathf.Sin(angle)*radius;

        if(!inCircle){
            this.RigidBody.MovePosition(this.RigidBody.position + ((new Vector2(x, y) - this.RigidBody.position).normalized * this.Speed * Time.fixedDeltaTime));
            if(Vector3.Distance(this.RigidBody.position, new Vector2(x, y)) < .2f)
                this.inCircle = true;
        }else{
            this.RigidBody.MovePosition(new Vector2(x, y));
        }

        
        return false; 

    }
}
