using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/NoMovement")]
public class NoMovementFactory : MovementFactory
{
    public override KinematicMovement Create(Vector2 target, Rigidbody2D rigidbody)
    {
        return new NoMovement(speed, target, rigidbody);
    }
}
