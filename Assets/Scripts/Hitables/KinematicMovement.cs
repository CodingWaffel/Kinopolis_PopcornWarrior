using UnityEngine;

public abstract class KinematicMovement{
    float speed;
    Vector2 target;
    Rigidbody2D rigidbody;

    public float Speed => this.speed;
    public Vector2 Target => this.target;
    public Rigidbody2D RigidBody => this.rigidbody; 

    public KinematicMovement(float speed, Vector2 target, Rigidbody2D rigidbody){
        this.speed = speed;
        this.target = target;
        this.rigidbody = rigidbody;
    }
    public abstract bool Move();
    public virtual bool TargetReached(){
        return Vector3.Distance(this.RigidBody.position, this.Target) < .1f;
    }
}