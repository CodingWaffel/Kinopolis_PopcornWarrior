using UnityEngine;

public class StraightMovement : KinematicMovement
{
    public StraightMovement(float speed, Vector2 target, Rigidbody2D rigidbody) : base(speed, target, rigidbody)
    {
    }

    public override bool Move()
    {
        this.RigidBody.MovePosition(this.RigidBody.position + (this.Target - this.RigidBody.position).normalized * this.Speed * Time.deltaTime);
        return this.TargetReached();
    }

    bool TargetReached(){
        return Vector3.Distance(this.RigidBody.position, this.Target) < .1f;
    }
}