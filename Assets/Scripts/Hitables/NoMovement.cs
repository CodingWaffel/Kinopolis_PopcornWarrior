using UnityEngine;

public class NoMovement : KinematicMovement
{
    public NoMovement(float speed, Vector2 target, Rigidbody2D rigidbody) : base(speed, target, rigidbody)
    {
    }

    public override bool Move()
    {
        return true;
    }
}