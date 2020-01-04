using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/CircularMovement")]
public class CircularMovementFactory : MovementFactory
{
    public float radius;
    public override KinematicMovement Create( Vector2 target, Rigidbody2D rigidbody)
    {
        return new CircleMovement(speed, this.GetNewTarget(target), rigidbody, this.radius);
    }
}
